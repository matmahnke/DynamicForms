using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
  public class PageViewModel
  {
    public PageViewModel()
    {
    }

    public PageViewModel(string name, string url, string title)
    {
      Name = name;
      Url = url;
      Title = title;
    }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Url { get; set; }

    [Required]
    public string Title { get; set; }
  }
}
