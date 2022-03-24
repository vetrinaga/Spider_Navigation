namespace Spider_Navigation.Models
{
    public class Calculate
    {
        private OutputModel _outputMopdel;

        public Calculate()
        {
            _outputMopdel = new OutputModel();
        }
        public OutputModel Calculate_Co_Ordinates(InputModel IO)
        {
            char[] chars = IO.Instrctions.ToCharArray();

            foreach (char c in chars)
            {
                if (c == 'F')
                {
                    if (IO.SpidDirection == "LEFT")
                    {
                        IO.SpidX -= 1; ;
                    }
                    else if (IO.SpidDirection == "RIGHT")
                    {
                        IO.SpidX += 1;
                    }
                    else if (IO.SpidDirection == "UP")
                    {
                        IO.SpidY += 1;
                    }
                    else
                    {
                        IO.SpidY -= 1;
                    }
                }
                else if (c == 'L')
                {
                    if (IO.SpidDirection == "LEFT")
                    {
                        IO.SpidDirection = "DOWN";

                    }
                    else if (IO.SpidDirection == "RIGHT")
                    {
                        IO.SpidDirection = "UP";
                    }
                    else if (IO.SpidDirection == "UP")
                    {
                        IO.SpidDirection = "LEFT";
                    }
                    else
                    {
                        IO.SpidDirection = "RIGHT";
                    }
                }
                else
                {
                    if (IO.SpidDirection == "LEFT")
                    {
                        IO.SpidDirection = "UP";

                    }
                    else if (IO.SpidDirection == "RIGHT")
                    {
                        IO.SpidDirection = "DOWN";
                    }
                    else if (IO.SpidDirection == "UP")
                    {
                        IO.SpidDirection = "RIGHT";
                    }
                    else
                    {
                        IO.SpidDirection = "LEFT";
                    }

                }
            }


            _outputMopdel.X = IO.SpidX;

            _outputMopdel.Y = IO.SpidY;

            _outputMopdel.Direction = IO.SpidDirection;


            return _outputMopdel;



        }
    }

}