﻿using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Components;
using AntDesign;

namespace ProLayout
{
    public partial class SelectLang
    {
        [Parameter] 
        public string[] Locales { get; set; } = { "zh-CN", "zh-TW", "en-US"};

        [Parameter]
        public string SelectedLocale { get; set; } = CultureInfo.CurrentCulture.Name;

        [Parameter]
        public IDictionary<string, string> LanguageLabels { get; set; } = new Dictionary<string, string>
        {
            ["zh-CN"] = "简体中文",
            ["zh-TW"] = "繁体中文",
            ["en-US"] = "English"
        };

        [Parameter] 
        public IDictionary<string, string> LanguageIcons { get; set; } = new Dictionary<string, string>
        {
            ["zh-CN"] = "🇨🇳",
            ["zh-TW"] = "🇭🇰",
            ["en-US"] = "🇺🇸"
        };

        [Parameter] 
        public EventCallback<MenuItem> OnItemSelected { get; set; }
    }
}