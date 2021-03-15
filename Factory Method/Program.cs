using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory_Method {
    class Program {
        static void Main(string[] args) {
            Document[] documents = new Document[2];
            documents[0] = new PageType1();
            documents[1] = new PageType2();

            foreach (var item in documents) {
                Console.WriteLine($"{item.GetType().Name}");
                foreach (var page in item.Pages) {
                    Console.WriteLine($"{page.GetType().Name}");
                }
            }

            Console.ReadLine();
        
        }
    }

    abstract class Page {

    }

    class SkillsPage : Page { }
    class DetailsPage : Page { }
    class ExtraPage : Page { }

    abstract class Document {
        private List<Page> _pages = new List<Page>();
        public Document() {
            this.CreatePages();
        }

        public List<Page> Pages {
            get { return _pages; }
        }

        public abstract void CreatePages();
    }

    class PageType1 : Document {
        public override void CreatePages() {
            Pages.Add(new SkillsPage());
            Pages.Add(new SkillsPage());
            Pages.Add(new DetailsPage());
        }
    }

    class PageType2 : Document {
        public override void CreatePages() {
            Pages.Add(new ExtraPage());
            Pages.Add(new SkillsPage());
            Pages.Add(new DetailsPage());
        }
    }
}
