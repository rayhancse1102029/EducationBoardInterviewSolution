using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationBoardInterviewSolution.Data.Entity.Auth;
using EducationBoardInterviewSolution.Services.Auth.Interfaces;

namespace EducationBoardInterviewSolution.Api.Auth
{   
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class NavbarAPIController : ControllerBase
    {
        private readonly INavbarService _navbarService;

        public NavbarAPIController(INavbarService _navbarService)
        {
            this._navbarService = _navbarService;
        }

        #region Navbar

        //GET: api/NavbarAPI/GetAllNavParentByModuleIdAPI/id
        [HttpGet("{moduleId}")]
        public async Task<IEnumerable<NavParent>> GetAllNavParentByModuleIdAPI(int moduleId)
        {
            return await _navbarService.GetAllNavParentByModuleId(moduleId);
        }

        //GET: api/NavbarAPI/GetAllNavBandByParentIdAPI/id
        [HttpGet("{parentId}")]
        public async Task<IEnumerable<NavBand>> GetAllNavBandByParentIdAPI(int parentId)
        {
            return await _navbarService.GetAllNavBandByParentId(parentId);
        }
        #endregion
    }
}
