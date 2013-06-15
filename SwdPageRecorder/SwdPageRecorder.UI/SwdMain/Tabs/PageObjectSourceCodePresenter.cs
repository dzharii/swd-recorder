using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwdPageRecorder.UI
{
    public class PageObjectSourceCodePresenter : IPresenter<PageObjectSourceCodeView>
    {
        
        private PageObjectSourceCodeView view;

        public void InitWithView(PageObjectSourceCodeView view)
        {
            this.view = view;
        }

        internal void GenerateSourceCodeForPageObject()
        {
            var definitions = Presenters.PageObjectDefinitionPresenter.GetWebElementDefinitionFromTree();
            var generator = new CSharpPageObjectGenerator();

            string[] code = generator.Generate(definitions);
            view.DisplayGeneratedCode(code);

        }
    }
}
