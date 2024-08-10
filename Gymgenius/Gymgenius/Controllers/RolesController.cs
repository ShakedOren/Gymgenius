using Gymgenius.bll;
using GymGenius.BO;
using Gymgenius.dal;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Gymgenius.bo;

namespace Gymgenius.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManagement _roleManagement;

        public RoleController(RoleManagement roleManagement)
        {
            _roleManagement = roleManagement;
        }

        [HttpGet("list_roles")]
        public async Task<ActionResult<IEnumerable<Role>>> GetAllRoles()
        {
            try
            {
                return await _roleManagement.GetAllRoles();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("get_role/{role}")]
        public async Task<ActionResult<Role>> GetRole(string role)
        {
            try
            {
                return await _roleManagement.GetRoleByName(role);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}