using System;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json;


[SerializePropertyNamesAsCamelCase]
public partial class Image {
	[System.ComponentModel.DataAnnotations.Key]
	
	[IsFilterable]
	public string ImageID { get; set; }

	[IsFilterable]
	public string ImageURL { get; set; }

	[IsSearchable]
	public string Caption { get; set; }

	[IsSearchable, IsFilterable, IsSortable]
	public string[] Tags{ get; set; }
}

