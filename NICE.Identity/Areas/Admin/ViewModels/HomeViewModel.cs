﻿using NICE.Identity.ViewModels;

namespace NICE.Identity.Areas.Admin.ViewModels
{
	public class HomeViewModel : BaseViewModel
    {
	    public HomeViewModel(string htmlHeadTitle, string pageTitle, bool isSignedIn) : base(htmlHeadTitle, pageTitle)
	    {
		    IsSignedIn = isSignedIn;
	    }

	    public bool IsSignedIn { get; }
    }
}
