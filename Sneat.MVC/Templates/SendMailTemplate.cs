using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sneat.MVC.Templates
{
    public class SendMailTemplate
    {
        public static string ForgotPasswordTemplate(string newPass)
        {
            string htmlContent = $@"
          <!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">
<html xmlns:v=""urn:schemas-microsoft-com:vml"">

<head>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
    <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" />
    <!--[if !mso]--><!-- -->
    <link href='https://fonts.googleapis.com/css?family=Work+Sans:300,400,500,600,700' rel=""stylesheet"">
    <link href='https://fonts.googleapis.com/css?family=Quicksand:300,400,700' rel=""stylesheet"">
    <!-- <![endif]-->

    <title>WesternTech VN</title>

    <style type=""text/css"">
        body {{
            width: 100%;
            background-color: #ffffff;
            margin: 0;
            padding: 0;
            -webkit-font-smoothing: antialiased;
            mso-margin-top-alt: 0px;
            mso-margin-bottom-alt: 0px;
            mso-padding-alt: 0px 0px 0px 0px;
        }}
        
        p,
        h1,
        h2,
        h3,
        h4 {{
            margin-top: 0;
            margin-bottom: 0;
            padding-top: 0;
            padding-bottom: 0;
        }}
        
        span.preheader {{
            display: none;
            font-size: 1px;
        }}
        
        html {{
            width: 100%;
        }}
        
        table {{
            font-size: 14px;
            border: 0;
        }}
        /* ----------- responsivity ----------- */
        
        @media only screen and (max-width: 640px) {{
            /*------ top header ------ */
            .main-header {{
                font-size: 20px !important;
            }}
            .main-section-header {{
                font-size: 28px !important;
            }}
            .show {{
                display: block !important;
            }}
            .hide {{
                display: none !important;
            }}
            .align-center {{
                text-align: center !important;
            }}
            .no-bg {{
                background: none !important;
            }}
            /*----- main image -------*/
            .main-image img {{
                width: 440px !important;
                height: auto !important;
            }}
            /* ====== divider ====== */
            .divider img {{
                width: 440px !important;
            }}
            /*-------- container --------*/
            .container590 {{
                width: 440px !important;
            }}
            .container580 {{
                width: 400px !important;
            }}
            .main-button {{
                width: 220px !important;
            }}
            /*-------- secions ----------*/
            .section-img img {{
                width: 320px !important;
                height: auto !important;
            }}
            .team-img img {{
                width: 100% !important;
                height: auto !important;
            }}
        }}
        
        @media only screen and (max-width: 479px) {{
            /*------ top header ------ */
            .main-header {{
                font-size: 18px !important;
            }}
            .main-section-header {{
                font-size: 26px !important;
            }}
            /* ====== divider ====== */
            .divider img {{
                width: 280px !important;
            }}
            /*-------- container --------*/
            .container590 {{
                width: 280px !important;
            }}
            .container590 {{
                width: 280px !important;
            }}
            .container580 {{
                width: 260px !important;
            }}
            /*-------- secions ----------*/
            .section-img img {{
                width: 280px !important;
                height: auto !important;
            }}
        }}
    </style>
    <!-- [if gte mso 9]><style type=”text/css”>
        body {{
        font-family: arial, sans-serif!important;
        }}
        </style>
    <![endif]-->
</head>


<body class=""respond"" leftmargin=""0"" topmargin=""0"" marginwidth=""0"" marginheight=""0"">
    <!-- pre-header -->
    <table style=""display:none!important;"">
        <tr>
            <td>
                <div style=""overflow:hidden;display:none;font-size:1px;color:#ffffff;line-height:1px;font-family:Arial;maxheight:0px;max-width:0px;opacity:0;"">
                    Pre-header for the newsletter template
                </div>
            </td>
        </tr>
    </table>
    <!-- pre-header end -->
    <!-- header -->
    <table border=""0"" width=""100%"" cellpadding=""0"" cellspacing=""0"" bgcolor=""ffffff"">

        <tr>
            <td align=""center"">
                <table border=""0"" align=""center"" width=""590"" cellpadding=""0"" cellspacing=""0"" class=""container590"">

                    <tr>
                        <td height=""25"" style=""font-size: 25px; line-height: 25px;"">&nbsp;</td>
                    </tr>

                    <tr>
                        <td align=""center"">

                            <table border=""0"" align=""center"" width=""590"" cellpadding=""0"" cellspacing=""0"" class=""container590"">

                                <tr>
                                    <div class=""app-brand justify-content-center mb-5"">
                                        <a href=""#"" class=""app-brand-link gap-2"">
                                            <span class=""app-brand-logo demo"">
                                                <svg width=""50""
                                                     viewBox=""0 0 25 42""
                                                     version=""1.1""
                                                     xmlns=""http://www.w3.org/2000/svg""
                                                     xmlns:xlink=""http://www.w3.org/1999/xlink"">
                                                    <defs>
                                                        <path d=""M13.7918663,0.358365126 L3.39788168,7.44174259 C0.566865006,9.69408886 -0.379795268,12.4788597 0.557900856,15.7960551 C0.68998853,16.2305145 1.09562888,17.7872135 3.12357076,19.2293357 C3.8146334,19.7207684 5.32369333,20.3834223 7.65075054,21.2172976 L7.59773219,21.2525164 L2.63468769,24.5493413 C0.445452254,26.3002124 0.0884951797,28.5083815 1.56381646,31.1738486 C2.83770406,32.8170431 5.20850219,33.2640127 7.09180128,32.5391577 C8.347334,32.0559211 11.4559176,30.0011079 16.4175519,26.3747182 C18.0338572,24.4997857 18.6973423,22.4544883 18.4080071,20.2388261 C17.963753,17.5346866 16.1776345,15.5799961 13.0496516,14.3747546 L10.9194936,13.4715819 L18.6192054,7.984237 L13.7918663,0.358365126 Z""
                                                              id=""path-1""></path>
                                                        <path d=""M5.47320593,6.00457225 C4.05321814,8.216144 4.36334763,10.0722806 6.40359441,11.5729822 C8.61520715,12.571656 10.0999176,13.2171421 10.8577257,13.5094407 L15.5088241,14.433041 L18.6192054,7.984237 C15.5364148,3.11535317 13.9273018,0.573395879 13.7918663,0.358365126 C13.5790555,0.511491653 10.8061687,2.3935607 5.47320593,6.00457225 Z""
                                                              id=""path-3""></path>
                                                        <path d=""M7.50063644,21.2294429 L12.3234468,23.3159332 C14.1688022,24.7579751 14.397098,26.4880487 13.008334,28.506154 C11.6195701,30.5242593 10.3099883,31.790241 9.07958868,32.3040991 C5.78142938,33.4346997 4.13234973,34 4.13234973,34 C4.13234973,34 2.75489982,33.0538207 2.37032616e-14,31.1614621 C-0.55822714,27.8186216 -0.55822714,26.0572515 -4.05231404e-15,25.8773518 C0.83734071,25.6075023 2.77988457,22.8248993 3.3049379,22.52991 C3.65497346,22.3332504 5.05353963,21.8997614 7.50063644,21.2294429 Z""
                                                              id=""path-4""></path>
                                                        <path d=""M20.6,7.13333333 L25.6,13.8 C26.2627417,14.6836556 26.0836556,15.9372583 25.2,16.6 C24.8538077,16.8596443 24.4327404,17 24,17 L14,17 C12.8954305,17 12,16.1045695 12,15 C12,14.5672596 12.1403557,14.1461923 12.4,13.8 L17.4,7.13333333 C18.0627417,6.24967773 19.3163444,6.07059163 20.2,6.73333333 C20.3516113,6.84704183 20.4862915,6.981722 20.6,7.13333333 Z""
                                                              id=""path-5""></path>
                                                    </defs>
                                                    <g id=""g-app-brand"" stroke=""none"" stroke-width=""1"" fill=""none"" fill-rule=""evenodd"">
                                                        <g id=""Brand-Logo"" transform=""translate(-27.000000, -15.000000)"">
                                                            <g id=""Icon"" transform=""translate(27.000000, 15.000000)"">
                                                                <g id=""Mask"" transform=""translate(0.000000, 8.000000)"">
                                                                    <mask id=""mask-2"" fill=""white"">
                                                                        <use xlink:href=""#path-1""></use>
                                                                    </mask>
                                                                    <use fill=""#696cff"" xlink:href=""#path-1""></use>
                                                                    <g id=""Path-3"" mask=""url(#mask-2)"">
                                                                        <use fill=""#696cff"" xlink:href=""#path-3""></use>
                                                                        <use fill-opacity=""0.2"" fill=""#FFFFFF"" xlink:href=""#path-3""></use>
                                                                    </g>
                                                                    <g id=""Path-4"" mask=""url(#mask-2)"">
                                                                        <use fill=""#696cff"" xlink:href=""#path-4""></use>
                                                                        <use fill-opacity=""0.2"" fill=""#FFFFFF"" xlink:href=""#path-4""></use>
                                                                    </g>
                                                                </g>
                                                                <g id=""Triangle""
                                                                   transform=""translate(19.000000, 11.000000) rotate(-300.000000) translate(-19.000000, -11.000000) "">
                                                                    <use fill=""#696cff"" xlink:href=""#path-5""></use>
                                                                    <use fill-opacity=""0.2"" fill=""#FFFFFF"" xlink:href=""#path-5""></use>
                                                                </g>
                                                            </g>
                                                        </g>
                                                    </g>
                                                </svg>
                                            </span>
                                            <h1><span class=""fw-bold"">Sneat</span></h1> 
                                        </a>
                                    </div>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td height=""25"" style=""font-size: 25px; line-height: 25px;"">&nbsp;</td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
    <!-- end header -->

    <!-- big image section -->
    <table border=""0"" width=""100%"" cellpadding=""0"" cellspacing=""0"" bgcolor=""ffffff"" class=""bg_color"">

        <tr>
            <td align=""center"">
                <table border=""0"" align=""center"" width=""590"" cellpadding=""0"" cellspacing=""0"" class=""container590"">
                    <tr>

                        <td align=""center"" class=""section-img"">
                            <a href="""" style="" border-style: none !important; display: block; border: 0 !important;""><img src=""https://res.cloudinary.com/dduv8pom4/image/upload/v1719937506/hero-services-img_c6vgq2.webp"" style=""display: block; width: 590px;"" width=""590"" border=""0"" alt="""" /></a>




                        </td>
                    </tr>
                    <tr>
                        <td height=""20"" style=""font-size: 20px; line-height: 20px;"">&nbsp;</td>
                    </tr>
                    <tr>
                        <td align=""center"" style=""color: #343434; font-size: 24px; font-family: Quicksand, Calibri, sans-serif; font-weight:700;letter-spacing: 3px; line-height: 35px;"" class=""main-header"">


                            <div style=""line-height: 35px"">

                                Mật khẩu mới của bạn là <span style=""color: #5caad2;"">{newPass}</span>
                            </div>
                        </td>
                    </tr>

                    <tr>
                        <td height=""10"" style=""font-size: 10px; line-height: 10px;"">&nbsp;</td>
                    </tr>

                    <tr>
                        <td align=""center"">
                            <table border=""0"" width=""40"" align=""center"" cellpadding=""0"" cellspacing=""0"" bgcolor=""eeeeee"">
                                <tr>
                                    <td height=""2"" style=""font-size: 2px; line-height: 2px;"">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td height=""20"" style=""font-size: 20px; line-height: 20px;"">&nbsp;</td>
                    </tr>

                    <tr>
                        <td align=""center"">
                            <table border=""0"" width=""400"" align=""center"" cellpadding=""0"" cellspacing=""0"" class=""container590"">
                                <tr>
                                    <td align=""center"" style=""color: #888888; font-size: 16px; font-family: 'Work Sans', Calibri, sans-serif; line-height: 24px;"">


                                        <div style=""line-height: 24px"">

                                            {{{{message}}}}
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td height=""25"" style=""font-size: 25px; line-height: 25px;"">&nbsp;</td>
                    </tr>

                </table>

            </td>
        </tr>

    </table>
    <!-- end section -->

</body>

</html>";

            return htmlContent;
        }
    }
}