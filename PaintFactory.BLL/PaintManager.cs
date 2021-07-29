using PaintFactory.Data;
using PaintFactory.Models.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaintFactory.BLL
{
    public class PaintManager
    {
        private readonly PaintRepository _paintRepository;

        public PaintManager()
        {
            _paintRepository = new PaintRepository();
        }

        public PaintLookupResponse LookupPaint(string days)
        {
            PaintLookupResponse response = new PaintLookupResponse
            {
                Paint = _paintRepository.LoadPaint()
            };

            // dont default to 0, that's a value we're trying to capture

            if (int.TryParse(days, out int parseDays))
            {
                // this is an int, make sure it's not negative
                if (parseDays >= 0)
                {
                    // its a positive int
                    response.Paint.Color = _paintRepository.ColorOfTheDay(parseDays);
                    response.Success = true;
                }
                else
                {
                    InvalidRequest(response, "Please enter a positive number");
                }
            }
            else
            {
                InvalidRequest(response, "Please enter a number between 0 and 2147483646");
            }
            return response;
        }

        public void InvalidRequest(PaintLookupResponse response, string ErrorMessage)
        {
            response.Success = false;
            response.Message = ErrorMessage;
        }
    }
}
