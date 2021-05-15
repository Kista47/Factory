using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PraktikaGamma.Models;
using PraktikaGamma.Repositories;

namespace PraktikaGamma.Services
{
    public class AdminService
    {
        private DepartmentRepository _departmentRepository;
        private AssembliesRepository _assembliesRepository;
        private DetailsRepository    _detailsRepository;

        public AdminService(DepartmentRepository departmentRepository, AssembliesRepository assembliesRepository, DetailsRepository detailsRepository)
        {
            _departmentRepository = departmentRepository;
            _assembliesRepository = assembliesRepository;
            _detailsRepository = detailsRepository;
        }

        public async Task CreateDepartment(Department department)
        {
            await _departmentRepository.CreateDepartment(department).ConfigureAwait(false);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _departmentRepository.GetDepartments().ConfigureAwait(false);
        }

        public async Task<IReadOnlyCollection<Assembley>> GetAssembleys()
        {
            return await _assembliesRepository.GetAssembleys().ConfigureAwait(false);
        }

        public async Task CreateAssembley(Assembley assembley)
        {
            await _assembliesRepository.CreateAssembley(assembley);
        }

        public async Task<IReadOnlyCollection<Detail>> GetDetails()
        {
            return await _detailsRepository.GetDetails().ConfigureAwait(false);
        }

        public async Task CreateDetail(Detail detail)
        {
            await _detailsRepository.CreateDetail(detail).ConfigureAwait(false);
        }

        public async Task<Detail> GetDetailById(int id)
        {
            return await _detailsRepository.GetDetailById(id).ConfigureAwait(false);
        }

    }
}
