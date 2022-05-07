using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos.SocialMediaIconDtos;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace FbProje.PersonalUl.TagHelpers
{  
    [HtmlTargetElement("GetIcons")]
    public class SocialMediaIconTagHelper:TagHelper
    {
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;
        private readonly ISocialMediaIconService _socialMediaIconService;
        public SocialMediaIconTagHelper(IAppUserService appUserService, IMapper mapper, ISocialMediaIconService socialMediaIconService)
        {
            _appUserService = appUserService;
            _mapper = mapper;
            _socialMediaIconService = socialMediaIconService;
        }


        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var icons = _mapper.Map<List<SocialMediaIconListDto>>(_socialMediaIconService.GetByUserId(AppUserId));
            string data = "<div class='social - icons'>";
            foreach (var item in icons)
            {
                data += $@"<a class='social-icon' href='{item.Link}'><i class='{item.Icon}'></i></a>";
            }
            data +="</div>";
            output.Content.SetHtmlContent(data);
        }
    }
}
