using Microsoft.AspNetCore.Mvc;
namespace viewmodel_fun.Controllers;
using viewmodel_fun.Models;
    public class MessageController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Message()
        {
            Message newMessage = new Message()
            {
                message = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Optio amet eveniet non reiciendis, dolorem facere eius cum quasi! Porro magni similique dolor nihil qui rerum deleniti aliquam delectus nesciunt modi. Tempora perferendis quod alias corrupti neque dolorum pariatur culpa autem ullam, explicabo quisquam voluptas, minima odio accusamus quaerat voluptates asperiores inventore consequuntur rerum repellat! Harum non reiciendis odio perferendis temporibus! \nCumque deserunt sapiente fuga expedita necessitatibus voluptatem voluptas aliquam architecto corporis nihil enim dolor nulla natus iure commodi, adipisci error, est officiis nostrum quasi ipsum tempora minus fugiat hic. Ea! Nulla, nisi soluta! Ullam veniam molestiae, officia, nostrum ducimus repudiandae deleniti dolor quo repellat dolore quod magni quis ex pariatur fugiat optio culpa provident dignissimos explicabo, atque soluta? Praesentium, culpa?"
            };
            return View(newMessage);
        }
    }