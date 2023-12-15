using Humanizer;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace web_project.Models
{
	public class Complaints
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Required]
		public int id { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]

		public string Email { get; set; }
		[Required]
		public int Number { get; set; }
		[Required]
		public string Complaint  { get; set; }
		[Required]
		public string City { get; set; }


    }
}
