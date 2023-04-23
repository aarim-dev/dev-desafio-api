namespace AarimChallenge.API.Data.Config
{
    public class RickAndMortyApiConfig
    {
        private readonly IConfiguration? _config;
        private readonly string _validationMessage = "{0} can't be null or empty, please check the config.";

        public string? BaseAddress { get; set; }
        public string? CharactersEnpoint { get; set; }

        public RickAndMortyApiConfig()
        {
        }

        public RickAndMortyApiConfig(IConfiguration config)
        {
            _config = config;
            Bind();
            Validate();
        }

        public void Bind()
        {
            var obj = _config?.GetSection("RickAndMortyAPI").Get<RickAndMortyApiConfig>();
            BaseAddress = obj?.BaseAddress;
            CharactersEnpoint = obj?.CharactersEnpoint;
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(BaseAddress))
                throw new Exception(string.Format(_validationMessage, nameof(BaseAddress)));

            if (string.IsNullOrEmpty(CharactersEnpoint))
                throw new Exception(string.Format(_validationMessage, nameof(CharactersEnpoint)));
        }
    }
}
