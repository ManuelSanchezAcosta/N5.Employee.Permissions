using Employee.Permissions.Api.Controllers;
using Employee.Permissions.Domain.Dtos.Internal;
using Employee.Permissions.Domain.Dtos.Requests;

namespace Employee.Permissions.XUniTests
{
    public class PermissionControllerTest
    {
        [Fact]
        public void GetGeneratedNewGuid()
        {

            PermissionCreateDto data = new PermissionCreateDto("1", "2",true );
            var controller = new PermissionController(data);


        }
    }
}