using Spider_Navigation.Models.ViewModel;

namespace Spider_Navigation.Models
{
    public class FormatEngine
    {

        public void Format(ref IOViewModel _input)
        {
            FormatDirections(ref _input);
            FormateInstructions(ref _input);
        }
        public void FormatDirections(ref IOViewModel _input)
        {
            _input.Input.SpidDirection = _input.Input.SpidDirection.ToString().ToUpper();
        }

        public void FormateInstructions(ref IOViewModel _input)
        {
            _input.Input.Instrctions = _input.Input.Instrctions.ToString().ToUpper();

        }
    }
}