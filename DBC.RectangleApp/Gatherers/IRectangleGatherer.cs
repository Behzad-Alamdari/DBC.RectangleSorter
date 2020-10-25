using DBC.Model;
using System.Collections.Generic;

namespace DBC.RectangleApp.Gatherers
{
    public interface IRectangleGatherer
    {
        /// <summary>
        /// Collect user input as a collection of rectangles
        /// </summary>
        /// <returns>Collection of rectangles inputed by user</returns>
        List<Rectangle> GetRectangles();
    }
}