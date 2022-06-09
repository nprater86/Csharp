using System.ComponentModel.DataAnnotations;
#pragma warning disable CS8618

namespace simple_login_registration.Models
{
    public class IndexViewModel
    {
        public RegUser regUser {get; set;}
        public LogUser logUser {get; set;}
    }
}