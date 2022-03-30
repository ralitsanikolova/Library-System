using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface ISectionRepository
    {
        public Task<SectionDTO> CreateSection(SectionDTO sectionDTO);
        public Task<SectionDTO> UpdateSection(int sectionId, SectionDTO sectionDTO);
        public Task<int> DeleteSection(int sectionId);
        public Task<SectionDTO> GetSection(int sectionId);
        public Task<SectionDTO> IsSectionUnique(string nameOfSection, int sectionId = 0);
        public Task<IEnumerable<SectionDTO>> GetAllSections();
    }
}
