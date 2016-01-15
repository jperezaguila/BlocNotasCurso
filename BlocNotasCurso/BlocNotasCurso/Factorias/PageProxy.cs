﻿using System;
using Xamarin.Forms;

namespace BlocNotasCurso.Factorias
{
    public class PageProxy:IPage
    {
        private readonly Func<Page> _page;

        public PageProxy(Func<Page> page)
        {
            _page = page;
        }

        public INavigation Navigation {
            get { return _page().Navigation; } 
        }
    }
}