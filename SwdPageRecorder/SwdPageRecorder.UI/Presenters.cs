using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SwdPageRecorder.UI
{
   
    public static class Presenters
    {
        private static SwdMainPresenter _swdMainPresenter = null;
        public static SwdMainPresenter SwdMainPresenter
        {
            get
            {
                return (_swdMainPresenter = _swdMainPresenter ?? new SwdMainPresenter());
            }
        }

        private static BrowserSettingsTabPresenter _browserSettingsTabPresenter = null;
        public static BrowserSettingsTabPresenter BrowserSettingsTabPresenter
        {
            get
            {
                return (_browserSettingsTabPresenter = _browserSettingsTabPresenter ?? new BrowserSettingsTabPresenter());
            }
        }

        private static PageObjectDefinitionPresenter _pageObjectDefinitionPresenter = null;
        public static PageObjectDefinitionPresenter PageObjectDefinitionPresenter
        {
            get
            {
                return (_pageObjectDefinitionPresenter = _pageObjectDefinitionPresenter ?? new PageObjectDefinitionPresenter());
            }
        }

        private static SelectorsEditPresenter _selectorsEditPresenter = null;
        public static SelectorsEditPresenter SelectorsEditPresenter
        {
            get
            {
                return (_selectorsEditPresenter = _selectorsEditPresenter ?? new SelectorsEditPresenter());
            }
        }

        private static HtmlDomTesterPresenter _htmlDomTesterPresenter = null;
        public static HtmlDomTesterPresenter HtmlDomTesterPresenter
        {
            get
            {
                return (_htmlDomTesterPresenter = _htmlDomTesterPresenter ?? new HtmlDomTesterPresenter());
            }
        }

        private static FullHtmlSourceTabPresenter _pageObjectSourceCodePresenter = null;
        public static FullHtmlSourceTabPresenter PageObjectSourceCodePresenter
        {
            get
            {
                return (_pageObjectSourceCodePresenter = _pageObjectSourceCodePresenter ?? new FullHtmlSourceTabPresenter());
            }
        }

        private static PageObjectSourceCodePresenter _fullHtmlSourceTabPresenter = null;
        public static PageObjectSourceCodePresenter FullHtmlSourceTabPresenter
        {
            get
            {
                return (_fullHtmlSourceTabPresenter = _fullHtmlSourceTabPresenter ?? new PageObjectSourceCodePresenter());
            }
        }


        private static JavascriptEditorTabPresenter _javascriptEditorTabPresenter = null;
        public static JavascriptEditorTabPresenter JavascriptEditorTabPresenter
        {
            get
            {
                return (_javascriptEditorTabPresenter = _javascriptEditorTabPresenter ?? new JavascriptEditorTabPresenter());
            }
        }

        private static PlayGroundPresenter _playGroundPresenter = null;
        public static PlayGroundPresenter PlayGroundPresenter
        {
            get
            {
                return (_playGroundPresenter = _playGroundPresenter ?? new PlayGroundPresenter());
            }
        }

        private static SwitchToPopupPresenter _switchToPopupPresenter = null;
        public static SwitchToPopupPresenter SwitchToPopupPresenter
        {
            get
            {
                return (_switchToPopupPresenter = _switchToPopupPresenter ?? new SwitchToPopupPresenter());
            }
        }

    }
}



