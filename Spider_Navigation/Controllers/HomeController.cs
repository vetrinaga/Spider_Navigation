using Spider_Navigation.Models;
using Spider_Navigation.Models.ViewModel;
using System.Web.Mvc;

namespace Spider_Navigation.Controllers
{
    public class HomeController : Controller
    {
        private IOViewModel _viewModel;
        private ValidateResult _validateResult;
        private ValidateEngine _validateEngine;
        private FormatEngine _formatEngine;

        public HomeController()
        {
            _viewModel = new IOViewModel();
            _validateResult = new ValidateResult();
            _validateEngine = new ValidateEngine();
            _formatEngine = new FormatEngine();
        }
        public ActionResult Index()
        {
            var _viewModel = new IOViewModel
            {
                Input = new InputModel(),
                Output = new OutputModel()
            };
            return View(_viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IOViewModel _input)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new IOViewModel
                {
                    Input = _input.Input,
                    Output = new OutputModel()
                };
                return View(viewModel);

            }
            else
            {
                _formatEngine.Format(ref _input);
                _validateResult = _validateEngine.Validate(_input.Input);

                if (_validateResult.Result == Message.Failure)
                {
                    return Redirect(_input, _validateResult);
                }

                Calculate calculate = new Calculate();
                OutputModel outputModel = calculate.Calculate_Co_Ordinates(_input.Input);

                _viewModel = new IOViewModel
                {
                    Input = _input.Input,
                    Output = outputModel
                };

                _validateResult = _validateEngine.ValidateSpidyCoOrdinates(_viewModel);

                if (_validateResult.Result == Message.Failure)
                {
                    return Redirect(_viewModel, _validateResult);
                }

            }
            return View(_viewModel);
        }

        public ActionResult Redirect(IOViewModel _input, ValidateResult _validateResult)
        {
            ModelState.AddModelError(_validateResult.Input, _validateResult.Input + " - " + _validateResult.Message);
            var viewModel = new IOViewModel
            {
                Input = _input.Input,
                Output = new OutputModel()
            };
            return View("Index", viewModel);
        }




    }
}