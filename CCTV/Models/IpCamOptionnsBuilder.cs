using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CCTV.Models
{
    public class IpCamOptionnsBuilder
    {
        /// <summary>
        /// Формирование строки запроса
        /// </summary>
        /// <param name="ipAddress">ip-адрес</param>
        /// <param name="param">Параметры запроса</param>
        /// <param name="typeCam">Тип камеры</param>
        /// <returns></returns>
        public String AddresGenerate(String ipAddress, String param, String typeCam)
        {
            String type = GetTypeCam(typeCam);
            String result = "http://" + ipAddress + type + param;
            return result;
        }

        /// <summary>
        /// Поддерживает ли камера MJPEG
        /// </summary>
        /// <param name="typeCam">Тип камеры</param>
        /// <returns></returns>
        public bool IsMJPEG(String typeCam)
        {
            if (typeCam == "axis"      ||
                typeCam == "pixord"    ||
                typeCam == "panasonic" ||
                typeCam == "d-link")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Формирование параметров строки запроса 
        /// в зависимости от типа камеры
        /// </summary>
        /// <param name="typeCam">Тип камеры</param>
        /// <returns></returns>
        private String GetTypeCam(String typeCam)
        {
            String result;
            switch (typeCam)
            {
                case "axis":
                    result = "/axis-cgi/mjpg/video.cgi";
                    break;
                case "startdot":
                    result = "/netcam.jpg";
                    break;
                case "pixord":
                    result = "/getimage";
                    break;
                case "panasonic":
                    result = "/nphMotionJpeg";
                    break;
                case "d-link":
                    result = "/cgi-bin/video.jpg";
                    break;
                default:
                    result = "/axis-cgi/mjpg/video.cgi";
                    break;
            }
            return result;
        }
    }
}