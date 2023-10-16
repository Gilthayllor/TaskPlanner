using System.Text.Json.Serialization;
using TaskPlanner.ViewModels.Enumerations;

namespace TaskPlanner.ViewModels
{
    public class ResultViewModel
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }

        [JsonIgnore]
        public ResultStatus Status { get; set; }

        public ResultViewModel()
        {
            Success = true;
            Errors = new List<string>();
            Status = ResultStatus.Success;
        }

        public ResultViewModel(IEnumerable<string> errors, ResultStatus resultStatus = ResultStatus.Error)
        {
            Success = false;
            Errors = new List<string>(errors);
            Status = resultStatus;
        }

        public ResultViewModel(string error, ResultStatus resultStatus = ResultStatus.Error)
        {
            Success = false;
            Errors = new List<string> { error };
            Status = resultStatus;
        }
    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public T? Data { get; set; }

        public ResultViewModel() : base()
        {

        }

        public ResultViewModel(string error, ResultStatus resultStatus = ResultStatus.Error) : base(error, resultStatus)
        {

        }

        public ResultViewModel(T data) : base()
        {
            Data = data;
        }

        public ResultViewModel(IEnumerable<string> errors, ResultStatus resultStatus = ResultStatus.Error) : base(errors, resultStatus)
        {

        }
    }
}
