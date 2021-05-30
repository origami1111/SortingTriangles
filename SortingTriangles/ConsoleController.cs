using System.Collections.Generic;

namespace SortingTriangles
{
    class ConsoleController
    {
        private View view;
        private string[] args;

        public ConsoleController(string[] args)
        {
            this.args = args;
        }
        public void Start()
        {
            view = new View();
            view.CheckArguments(args);
            List<Triangle> triangles = view.SetTriangles();
            view.PrintTriangles(triangles);
        }
    }
}
