using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class SectionRepository : ISectionRepository
    {
        private readonly OnlineLibraryDbContext _db;
        private readonly IMapper _mapper;

        public SectionRepository(OnlineLibraryDbContext db, IMapper mapper)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<SectionDTO> CreateSection(SectionDTO sectionDTO)
        {
            Section section = _mapper.Map<SectionDTO, Section>(sectionDTO);
            section.CreatedDate = DateTime.Now;
            section.CreatedBy = "";
            var addedSection = await _db.Sections.AddAsync(section);
            await _db.SaveChangesAsync();
            return _mapper.Map<Section, SectionDTO>(addedSection.Entity);
        }

        public async Task<int> DeleteSection(int sectionId)
        {
            var sectionDetail = await _db.Books.FindAsync(sectionId);
            if (sectionDetail != null)
            {
                _db.Books.Remove(sectionDetail);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<SectionDTO>> GetAllSections()
        {
            try
            {
                IEnumerable<SectionDTO> sectionDTOs =
                    _mapper.Map<IEnumerable<Section>, IEnumerable<SectionDTO>>(_db.Sections);

                return sectionDTOs;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SectionDTO> GetSection(int sectionId)
        {
            try
            {
                SectionDTO book = _mapper.Map<Section, SectionDTO>(
                    await _db.Sections
                    .Include(x => x.Books.Select(y => y.Book))
                    .FirstOrDefaultAsync(x => x.SectionId == sectionId));

                return book;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SectionDTO> IsSectionUnique(string nameOfSection, int sectionId = 0)
        {
            try
            {
                if (sectionId == 0)
                {
                    SectionDTO book = _mapper.Map<Section, SectionDTO>(
                                        await _db.Sections.FirstOrDefaultAsync(x => x.Name == nameOfSection.ToLower()));

                    return book;
                }
                else
                {

                    SectionDTO book = _mapper.Map<Section, SectionDTO>(
                                        await _db.Sections.FirstOrDefaultAsync(x => x.Name == nameOfSection.ToLower() && x.SectionId != sectionId));

                    return book;
                }


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<SectionDTO> UpdateSection(int sectionId, SectionDTO sectionDTO)
        {
            try
            {
                if (sectionId == sectionDTO.SectionId)
                {
                    Section sectionDetails = await _db.Sections.FindAsync(sectionId);
                    Section sectionMap = _mapper.Map<SectionDTO, Section>(sectionDTO, sectionDetails);

                    sectionMap.UpdatedBy = "";
                    sectionMap.UpdatedDate = DateTime.Now;

                    var updatedBook = _db.Sections.Update(sectionMap);

                    await _db.SaveChangesAsync();
                    return _mapper.Map<Section, SectionDTO>(updatedBook.Entity);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
