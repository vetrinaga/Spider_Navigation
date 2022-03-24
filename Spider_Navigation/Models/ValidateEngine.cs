using Spider_Navigation.Models.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace Spider_Navigation.Models
{
    public class ValidateEngine
    {
        private ValidateResult _validateResult;

        public ValidateEngine()
        {
            _validateResult = new ValidateResult();
        }

        public ValidateResult Validate(InputModel _input)
        {
            ValidateDirection(_input);
            ValidateInstructions(_input);
            ValidateSpidyLocation(_input);
            if (_validateResult.Result == Message.Default)
            {
                _validateResult.Result = Message.Success;
                _validateResult.Message = MessageExtensions.Vaidation;
            }
            return _validateResult;
        }
        public void ValidateDirection(InputModel _input)
        {
            List<string> directions = new List<string>();
            directions.Add("LEFT");
            directions.Add("RIGHT");
            directions.Add("UP");
            directions.Add("DOWN");
            bool _result = directions.Any(s => _input.SpidDirection.Contains(s));

            if (!_result)

            {
                _validateResult.Result = Message.Failure;
                _validateResult.Message = MessageExtensions.InValidDirection;

                _validateResult.Input = nameof(_input.SpidDirection);
            }

        }

        public void ValidateInstructions(InputModel _input)
        {

            bool _result = System.Text.RegularExpressions.Regex.IsMatch(_input.Instrctions, "^[FLR]*$");
            if (!_result)
            {

                _validateResult.Result = Message.Failure;
                _validateResult.Message = MessageExtensions.InValidInstruction;
                _validateResult.Input = nameof(_input.Instrctions);

            }

        }

        public void ValidateSpidyLocation(InputModel _input)
        {
            if (_input.RectX < _input.SpidX)

            {
                _validateResult.Input = nameof(_input.SpidX);
                _validateResult.Result = Message.Failure;
                _validateResult.Message = MessageExtensions.InvalidSpidyLocation;

            }
            else if (_input.RectY < _input.SpidY)
            {
                _validateResult.Input = nameof(_input.SpidY);
                _validateResult.Result = Message.Failure;
                _validateResult.Message = MessageExtensions.InvalidSpidyLocation;

            }

        }

        public ValidateResult ValidateSpidyCoOrdinates(IOViewModel _ioViewModel)
        {
            if (_ioViewModel.Input.RectX < _ioViewModel.Output.X || _ioViewModel.Input.RectY < _ioViewModel.Output.Y)

            {
                _validateResult.Result = Message.Failure;
                _validateResult.Message = MessageExtensions.InvalidSpidyCoordinates;
                _validateResult.Input = nameof(_ioViewModel.Input.Instrctions);
            }
            else
            {
                _validateResult.Result = Message.Success;
                _validateResult.Message = MessageExtensions.ValidSpidyCoordinates;
                _validateResult.Input = nameof(_ioViewModel.Input.Instrctions);
            }
            return _validateResult;

        }




    }
}