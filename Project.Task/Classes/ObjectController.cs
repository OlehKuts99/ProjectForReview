using System;
using Project.Task.Interfaces;

namespace Project.Task.Classes
{
    static class ObjectController
    {
        public static int ObjectCount { get; set; } = 0;

        public static int CurrentObject { get; set; } = 0;

        public static string Regime { get; private set; } = "Move"; 

        /// <summary>
        /// Performs certain action on the object.
        /// </summary>
        /// <param name="obj">Object to be changed.</param>
        /// <param name="keyInfo">Code of key which user pushed.</param>
        public static void ObjectAction(IChangeable obj, int keyInfo)
        {
            UIPart.Counter = 0;
            UIPart.Writer.SetCursorPosition(0, 0);

            dynamic manageObject;

            if (obj is ICircle)
            {
                manageObject = obj as ICircle;
            }
            else
            {
                manageObject = obj as IRectangle;
            }

            if (keyInfo == (int)ConsoleKey.N)
            {
                CurrentObject++;
                if (CurrentObject == ObjectCount)
                {
                    CurrentObject = 0;
                }

                return;
            }

            if (keyInfo == (int)ConsoleKey.P)
            {
                CurrentObject--;
                if (CurrentObject < 0)
                {
                    CurrentObject = ObjectCount - 1;
                }

                return;
            }

            if (keyInfo == (int)ConsoleKey.M)
            {
                Regime = "Move";

                return;
            }

            if (keyInfo == (int)ConsoleKey.S)
            {
                Regime = "Size";

                return;
            }

            switch (keyInfo)
            {
                case (int)ConsoleKey.LeftArrow:
                    {
                        if (Regime == "Move")
                        {
                            manageObject.Move(-1, 0);
                        }
                        else
                        {
                            if (obj is ICircle)
                            {
                                manageObject.Resize(-1);
                            }
                            else
                            {
                                manageObject.Resize(0, -1);
                            }
                        };

                        break;
                    }

                case (int)ConsoleKey.RightArrow:
                    {
                        if (Regime == "Move")
                        {
                            manageObject.Move(1, 0);
                        }
                        else
                        {
                            if (obj is ICircle)
                            {
                                manageObject.Resize(1);
                            }
                            else
                            {
                                manageObject.Resize(0, 1);
                            }
                        };

                        break;
                    }

                case (int)ConsoleKey.UpArrow:
                    {
                        if (Regime == "Move")
                        {
                            manageObject.Move(0, -1);
                        }
                        else
                        {
                            if (manageObject is IRectangle)
                            {
                                manageObject.Resize(1, 0);
                            }
                        };

                        break;
                    }

                case (int)ConsoleKey.DownArrow:
                    {
                        if (Regime == "Move")
                        {
                            manageObject.Move(0, 1);
                        }
                        else
                        {
                            if (manageObject is IRectangle)
                            {
                                manageObject.Resize(-1, 0);
                            }
                        };

                        break;
                    }
            }
        }
    }
}
