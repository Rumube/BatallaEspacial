using System;

namespace UI
{
    public interface InGameMenuMediator
    {
        public void OnBackToMenuPressed();

        public void OnResumePressed();

        public void OnRestartPressed();
    }
}