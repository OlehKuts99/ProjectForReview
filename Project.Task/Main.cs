using System;
using System.Collections.Generic;
using Project.Common.Core.Interfaces;
using Project.Task.Classes;
using Project.Task.Interfaces;

namespace Project.Task
{
    public class Main : IRunnable
    {
        /// <summary>
        /// This is general task method, here is described logic of types behavior.
        /// </summary>
        /// <param name="view">Type of class, which response for input/output information in program.</param>
        public void Run(IInformation view)
        {
            UIPart.Writer = view;
            List<IDrawable> drawFigures = new List<IDrawable>();
            IDrawable coordinateSystem = new CoordinateSystem(view);
            List<IChangeable> objects = new List<IChangeable>()
            {
                new Circle(view, 5),
                new Rectangle(view, 12, 10, new Point(1, 3)),
            };

            ObjectController.ObjectCount = objects.Count;
            foreach (var obj in objects)
            {
                drawFigures.Add(obj);
            }
            
            UIPart.DrawLine();
            coordinateSystem.Draw();
            do
            {
                foreach (var obj in drawFigures)
                {
                    obj.Draw();
                }

                var keyInfo = view.ReadKey(true);
                view.Clear(CoordinateSystem.EndOfUserUI);

                foreach (var obj in drawFigures)
                {
                    obj.Draw(' ');
                }

                try
                {
                    ObjectController.ObjectAction(objects[ObjectController.CurrentObject], keyInfo);
                }
                catch (NullReferenceException e)
                {
                    UIPart.PrintString(e.Message);
                }
                
                UIPart.PrintStats(objects[ObjectController.CurrentObject]);
            }
            while (true);
        }
    }
}
