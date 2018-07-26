using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Newtonsoft.Json;
using Shared.DTO;
using Shared.Exceptions;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public class CrewService : ICrewService
    {
        private IRepository<Crew> crewRepository;
        IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<CrewDTO, Crew>().ForMember(x=>x.Stewardesses,opt=>opt.Ignore())).CreateMapper();


        public CrewService(IRepository<Crew> _crewRepository)
        {
            crewRepository = _crewRepository;
        }

        public async Task<CrewDTO> GetEntityAsync(int id)
        {
            var crew = await crewRepository.GetAsync(id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {id} not found");

            return mapper.Map<CrewDTO>(crew);
        }

        public async  Task<IEnumerable<CrewDTO>> GetEntitiesAsync()
        {
            return mapper.Map<IEnumerable<Crew>, List<CrewDTO>>(await crewRepository.GetAllAsync());
        }

        public async Task CreateEntityAsync(CrewDTO crewDTO)
        {
            await crewRepository.AddAsync(mapper.Map<CrewDTO, Crew>(crewDTO)).ConfigureAwait(false);
        }

        public async Task UpdateEntityAsync(int id,CrewDTO crewDTO)
        {
            var crew = await crewRepository.GetAsync(id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {id} not found");

           await crewRepository.UpdateAsync(crew).ConfigureAwait(false);
        }

        public async Task DeleteAllEntitiesAsync()
        {
            await crewRepository.DeleteAllAsync().ConfigureAwait(false);
        }

        public async Task DeleteEntityAsync(int id)
        {
            var crew = await crewRepository.GetAsync(id);

            if (crew == null)
                throw new ValidationException($"Crew with this id {id} not found");

            await crewRepository.DeleteAsync(crew).ConfigureAwait(false);
        }

        public async Task Add10CrewIntoDbAndFileAsync()
        {
            string page = "http://5b128555d50a5c0014ef1204.mockapi.io/crew";
            string result = "";
            string path = "log_2018.07.18_23.20.csv";
            StringBuilder csvContent=new StringBuilder();
            List<Crew> crews = new List<Crew>();

            string crewContent="", pilotContent="", stewardessContent="";

            HttpClient client = new HttpClient();
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                result = await content.ReadAsStringAsync();
            }

            crews = JsonConvert.DeserializeObject<List<Crew>>(result);

            var first10Crews = crews.GetRange(0, 10);

            csvContent.AppendLine("Crew Id,Pilot Id,Pilot First Name,Pilot Last Name,Pilot Experience,Pilot Crew Id"+
                "Stewardess Id,Stewardess First Name,Stewardess Last Name,Stewardess Crew Id");
            foreach (var crew in first10Crews)
            {
                foreach (var pilot in crew.Pilots)
                {
                    pilotContent=$"{pilot.Id},{pilot.FirstName},{pilot.LastName},{pilot.Experience},{pilot.CrewId}";
                    pilot.Id = 0;
                }
                foreach (var stew in crew.Stewardesses)
                {
                    csvContent.AppendLine($"{crew.Id},"+ pilotContent+$",{stew.Id},{stew.FirstName},{stew.LastName},{stew.CrewId}");
                    stew.Id = 0;
                }
                crew.Id=0;
            }

            await Task.WhenAll(crewRepository.AddRangeAsync(first10Crews),
                File.AppendAllTextAsync(path, csvContent.ToString()));
        }
    }
}
