using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SeleniumAXE.Utilities
{
    public static class StringHelper
    {
        public static String ReplaceDynamicValues(this string value)
        {
            //Replace dynamic values
            if (Strings.GetMatchCountFromString(value, "([<].*[>])") > 0)
            {
                //Let's replace any context variables first
                while (value.Contains("ScenarioContext"))
                {
                    string fullText = Strings.GetMatchFromString(value, "(<ScenarioContext[^>]*:[^>]*>)");
                    int last = 0, first = 0;
                    if (fullText.Contains("ScenarioContext.Last"))
                        last = int.Parse(Strings.GetMatchFromString(fullText, "[(](.*)[)]"));
                    else if (fullText.Contains("ScenarioContext.First"))
                        first = int.Parse(Strings.GetMatchFromString(fullText, "[(](.*)[)]"));

                    string valueToReplace = Strings.GetMatchFromString(value, "<ScenarioContext[^>]*:([^>]*)>");
                    string newValue = ScenarioContext.Current.Get<String>(valueToReplace);
                    if (last > 0)
                        newValue = Strings.Last(newValue, last);
                    else if (first > 0)
                        newValue = Strings.First(newValue, first);
                    value = value.Replace(fullText, newValue);

                }

                //Then any unique numbers
                if (value.Contains("<random"))
                {
                    var validNumbers = "123456789";
                    var validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    string matchedText = Strings.GetMatchFromString(value, "(<random[^>]*>)");
                    string valueToReplace = Strings.GetMatchFromString(value, "<random([^>]*)>");
                    string replacementValue = "";
                    Random rnd = new Random();
                    for (int i = 0; i < valueToReplace.Length; i++)
                    {
                        if (valueToReplace[i].Equals('9'))
                        {
                            replacementValue = replacementValue + validNumbers[rnd.Next(validNumbers.Length)];
                        }
                        else
                        {
                            replacementValue = replacementValue + validChars[rnd.Next(validChars.Length)];
                        }
                    }
                    value = value.Replace(matchedText, replacementValue);
                }

                //Then date manipulation
                if (value.Contains("<today>"))
                    value = value.Replace("<today>", DateTime.Now.ToString("dd/MM/yyyy"));
                if (value.Contains("<tomorrow>"))
                    value = value.Replace("<tomorrow>", DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"));


                if (Strings.GetMatchCountFromString(value, "(<today[ ]?[+-][ ]?[0-9]+[ ]?day[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<today[ ]?[+-][ ]?[0-9]+[ ]?day[s]?>)");
                    string matchedText = Strings.GetMatchFromString(value, "<today([ ]?[+-][ ]?[0-9]+[ ]?)day[s]?>");
                    value = value.Replace(fullText, DateTime.Today.AddDays(Int32.Parse(matchedText.Replace(" ", ""))).ToString("dd/MM/yyyy"));
                }
                if (Strings.GetMatchCountFromString(value, "(<today[ ]?[+-][ ]?[0-9]+[ ]?working day[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<today[ ]?[+-][ ]?[0-9]+[ ]?working day[s]?>)");
                    string matchedText = Strings.GetMatchFromString(value, "<today([ ]?[+-][ ]?[0-9]+[ ]?)working day[s]?>");
                    DateTime dateValue = DateTime.Today;
                    if (matchedText.Replace(" ", "").Contains("-"))
                    {
                        for (int i = 0; i < Int32.Parse(matchedText.Replace("-", "")); i++)
                        {
                            dateValue = dateValue.AddDays(-1);
                            if (dateValue.DayOfWeek.Equals(DayOfWeek.Saturday))
                            {
                                dateValue = dateValue.AddDays(-1);
                            }
                            else if (dateValue.DayOfWeek.Equals(DayOfWeek.Sunday))
                            {
                                dateValue = dateValue.AddDays(-2);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Int32.Parse(matchedText.Replace("+", "")); i++)
                        {
                            dateValue = dateValue.AddDays(1);
                            if (dateValue.DayOfWeek.Equals(DayOfWeek.Saturday))
                            {
                                dateValue = dateValue.AddDays(2);
                            }
                            else if (dateValue.DayOfWeek.Equals(DayOfWeek.Sunday))
                            {
                                dateValue = dateValue.AddDays(1);
                            }
                        }
                    }
                    value = value.Replace(fullText, dateValue.ToString("dd/MM/yyyy"));
                }
                if (Strings.GetMatchCountFromString(value, "(<today[ ]?[+-][ ]?[0-9]+[ ]?month[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<today[ ]?[+-][ ]?[0-9]+[ ]?month[s]?>)");
                    string matchedText = Strings.GetMatchFromString(value, "<today([ ]?[+-][ ]?[0-9]+[ ]?)month[s]?>");
                    value = value.Replace(fullText, DateTime.Today.AddMonths(Int32.Parse(matchedText.Replace(" ", ""))).ToString("dd/MM/yyyy"));
                }
                if (Strings.GetMatchCountFromString(value, "(<today[ ]?[+-][ ]?[0-9]+[ ]?year[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<today[ ]?[+-][ ]?[0-9]+[ ]?year[s]?>)");
                    string matchedText = Strings.GetMatchFromString(value, "<today([ ]?[+-][ ]?[0-9]+[ ]?)year[s]?>");
                    value = value.Replace(fullText, DateTime.Today.AddYears(Int32.Parse(matchedText.Replace(" ", ""))).ToString("dd/MM/yyyy"));
                }
                if (Strings.GetMatchCountFromString(value, "(<[-]?[0-9]+[ ]?year[s]?[ ]?[+-][ ]?[0-9]+[ ]?day[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<[-]?[0-9]+[ ]?year[s]?[ ]?[+-][ ]?[0-9]+[ ]?day[s]?>)");
                    string regex = "<([-]?[0-9]+)[ ]?year[s]?[ ]?([+-][ ]?[0-9]+)[ ]?day[s]?>";
                    string[] matchedYearText = Strings.GetMultipleMatchesFromString(value, regex, 1);
                    string[] matchedDayText = Strings.GetMultipleMatchesFromString(value, regex, 2);
                    value = value.Replace(fullText, DateTime.Today.AddYears(Int32.Parse(matchedYearText[0].Replace(" ", ""))).AddDays(Int32.Parse(matchedDayText[0].Replace(" ", ""))).ToString("dd/MM/yyyy"));
                }
                if (Strings.GetMatchCountFromString(value, "(<[-]?[0-9]+[ ]?month[s]?[ ]?[+-][ ]?[0-9]+[ ]?day[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<[-]?[0-9]+[ ]?month[s]?[ ]?[+-][ ]?[0-9]+[ ]?day[s]?>)");
                    string regex = "<([-]?[0-9]+)[ ]?month[s]?[ ]?([+-][ ]?[0-9]+)[ ]?day[s]?>";
                    string[] matchedMonthText = Strings.GetMultipleMatchesFromString(value, regex, 1);
                    string[] matchedDayText = Strings.GetMultipleMatchesFromString(value, regex, 2);
                    value = value.Replace(fullText, DateTime.Today.AddMonths(Int32.Parse(matchedMonthText[0].Replace(" ", ""))).AddDays(Int32.Parse(matchedDayText[0].Replace(" ", ""))).ToString("dd/MM/yyyy"));
                }
                if (Strings.GetMatchCountFromString(value, "(<next (Mon|Tues|Wednes|Thurs|Fri|Satur|Sun)day>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<next (Mon|Tues|Wednes|Thurs|Fri|Satur|Sun)day>)");
                    string matchedText = Strings.GetMatchFromString(value, "<next ((Mon|Tues|Wednes|Thurs|Fri|Satur|Sun)day)>");
                    DayOfWeek dayToReturn = ((DayOfWeek)Enum.Parse(typeof(DayOfWeek), matchedText));

                    // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
                    int daysUntil = ((int)dayToReturn - (int)DateTime.Today.AddDays(1).DayOfWeek + 7) % 7;
                    daysUntil++;
                    value = value.Replace(fullText, DateTime.Today.AddDays(daysUntil).ToString("dd/MM/yyyy"));
                }

                //Further date manipulation
                if (Strings.GetMatchCountFromString(value, "(<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?[+-][ ]?[0-9]+[ ]?month[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?[+-][ ]?[0-9]+[ ]?month[s]?>)");
                    DateTime date = DateTime.ParseExact(Strings.GetMatchFromString(value, "([0-9]{2}\\/[0-9]{2}\\/[0-9]{4})"), "dd/MM/yyyy", null);
                    string regex = "<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?([+-][ ]?[0-9]+)[ ]?month[s]?>";
                    string[] matchedMonthText = Strings.GetMultipleMatchesFromString(value, regex, 1);
                    value = value.Replace(fullText, date.AddMonths(Int32.Parse(matchedMonthText[0].Replace(" ", ""))).ToString("dd/MM/yyyy"));
                }
                if (Strings.GetMatchCountFromString(value, "(<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?[+-][ ]?[0-9]+[ ]?day[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?[+-][ ]?[0-9]+[ ]?day[s]?>)");
                    DateTime date = DateTime.ParseExact(Strings.GetMatchFromString(value, "([0-9]{2}\\/[0-9]{2}\\/[0-9]{4})"), "dd/MM/yyyy", null);
                    string regex = "<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?([+-][ ]?[0-9]+)[ ]?day[s]?>";
                    string[] matchedDayText = Strings.GetMultipleMatchesFromString(value, regex, 1);
                    value = value.Replace(fullText, date.AddDays(Int32.Parse(matchedDayText[0].Replace(" ", ""))).ToString("dd/MM/yyyy"));
                }
                if (Strings.GetMatchCountFromString(value, "(<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?[+-][ ]?[0-9]+[ ]?working day[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?[+-][ ]?[0-9]+[ ]?working day[s]?>)");
                    DateTime dateValue = DateTime.ParseExact(Strings.GetMatchFromString(value, "([0-9]{2}\\/[0-9]{2}\\/[0-9]{4})"), "dd/MM/yyyy", null);
                    string regex = "<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}[ ]?([+-][ ]?[0-9]+)[ ]?working day[s]?>";
                    string[] matchedDayText = Strings.GetMultipleMatchesFromString(value, regex, 1);

                    if (matchedDayText[0].Replace(" ", "").Contains("-"))
                    {
                        for (int i = 0; i < Int32.Parse(matchedDayText[0].Replace("-", "")); i++)
                        {
                            dateValue = dateValue.AddDays(-1);
                            if (dateValue.DayOfWeek.Equals(DayOfWeek.Saturday))
                            {
                                dateValue = dateValue.AddDays(-1);
                            }
                            else if (dateValue.DayOfWeek.Equals(DayOfWeek.Sunday))
                            {
                                dateValue = dateValue.AddDays(-2);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Int32.Parse(matchedDayText[0].Replace("+", "")); i++)
                        {
                            dateValue = dateValue.AddDays(1);
                            if (dateValue.DayOfWeek.Equals(DayOfWeek.Saturday))
                            {
                                dateValue = dateValue.AddDays(2);
                            }
                            else if (dateValue.DayOfWeek.Equals(DayOfWeek.Sunday))
                            {
                                dateValue = dateValue.AddDays(1);
                            }
                        }
                    }
                    value = value.Replace(fullText, dateValue.ToString("dd/MM/yyyy"));
                }

                //Then Time manipulation
                DateTime manipulatedDateForTime = DateTime.Now;
                if (value.Contains("<currentTime>"))
                    value = value.Replace("<currentTime>", manipulatedDateForTime.ToString("HH:mm"));
                if (Strings.GetMatchCountFromString(value, "(<currentTime[ ]?[+-][ ]?[0-9]+[ ]?minute[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<currentTime[ ]?[+-][ ]?[0-9]+[ ]?minute[s]?>)");
                    string matchedText = Strings.GetMatchFromString(value, "<currentTime([ ]?[+-][ ]?[0-9]+[ ]?)minute[s]?>");
                    manipulatedDateForTime = DateTime.Now.AddMinutes(Int32.Parse(matchedText.Replace(" ", "")));
                    value = value.Replace(fullText, manipulatedDateForTime.ToString("HH:mm"));
                }

                if (Strings.GetMatchCountFromString(value, "(<currentTime[ ]?[+-][ ]?[0-9]+[ ]?hour[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<currentTime[ ]?[+-][ ]?[0-9]+[ ]?hour[s]?>)");
                    string matchedText = Strings.GetMatchFromString(value, "<currentTime([ ]?[+-][ ]?[0-9]+[ ]?)hour[s]?>");
                    manipulatedDateForTime = DateTime.Now.AddHours(Int32.Parse(matchedText.Replace(" ", "")));
                    value = value.Replace(fullText, manipulatedDateForTime.ToString("HH:mm"));
                }

                if (Strings.GetMatchCountFromString(value, "(<currentTime[ ]?[+-][ ]?[0-9]+[ ]?hour[s]?[ ]?[+-][ ]?[0-9]+[ ]?minute[s]?>)") > 0)
                {
                    string fullText = Strings.GetMatchFromString(value, "(<currentTime[ ]?[+-][ ]?[0-9]+[ ]?hour[s]?[ ]?[+-][ ]?[0-9]+[ ]?minute[s]?>)");
                    string regex = "<currentTime([ ]?[+-][ ]?[0-9]+)[ ]?hour[s]?[ ]?([+-][ ]?[0-9]+)[ ]?minute[s]?>";
                    string[] matchedHourText = Strings.GetMultipleMatchesFromString(value, regex, 1);
                    string[] matchedMinuteText = Strings.GetMultipleMatchesFromString(value, regex, 2);
                    manipulatedDateForTime = DateTime.Now.AddHours(Int32.Parse(matchedHourText[0].Replace(" ", ""))).AddMinutes(Int32.Parse(matchedMinuteText[0].Replace(" ", "")));
                    value = value.Replace(fullText, manipulatedDateForTime.ToString("HH:mm"));
                }

                if (value.Contains(":uniquetime"))
                {
                    //Looking for matches ending in 0 e.g. 10:50
                    if (Strings.GetMatchCountFromString(value, "([0-9]{2}:[0-9]{2})") > 0)
                    {
                        string valueToReplace = Strings.GetMatchFromString(value, "(<[0-9]{2}:[0-9]{2}:uniquetime>)");
                        string matchedText = Strings.GetMatchFromString(value, "([0-9]{2}:[0-9]{2})");
                        string replacementValue = matchedText;
                        if (matchedText.EndsWith("0"))
                            replacementValue = matchedText.Substring(0, matchedText.Length - 1) + "1";
                        value = value.Replace(valueToReplace, replacementValue);
                    }

                }


                //Then apply any date formatting
                if (value.Contains(":format"))
                {
                    if (Strings.GetMatchCountFromString(value, "([0-9]{2}\\/[0-9]{2}\\/[0-9]{4}:format)") > 0)
                    {
                        string valueToReplace = Strings.GetMatchFromString(value, "(<[0-9]{2}\\/[0-9]{2}\\/[0-9]{4}:format{.*}>)");
                        DateTime date = DateTime.ParseExact(Strings.GetMatchFromString(value, "([0-9]{2}\\/[0-9]{2}\\/[0-9]{4})"), "dd/MM/yyyy", null);
                        string dateFormat = Strings.GetMatchFromString(value, "([{].*[}])");
                        dateFormat = dateFormat.Trim(new char[] { '{', '}' });
                        string valueToUse = string.Format("{0:" + dateFormat + "}", date);
                        value = value.Replace(valueToReplace, valueToUse);
                    }
                    if (Strings.GetMatchCountFromString(value, "([0-9]{2}:[0-9]{2}:format)") > 0)
                    {
                        string valueToReplace = Strings.GetMatchFromString(value, "(<[0-9]{2}:[0-9]{2}:format{.*}>)");
                        string dateFormat = Strings.GetMatchFromString(value, "([{].*[}])");
                        dateFormat = dateFormat.Trim(new char[] { '{', '}' });
                        value = value.Replace(valueToReplace, string.Format("{0:" + dateFormat + "}", manipulatedDateForTime));
                    }
                }

                if (value.Contains("<sum:"))
                {
                    string matchedText = Strings.GetMatchFromString(value, "(<sum:[^>]*>)");
                    string firstValueToReplace = Strings.GetMatchFromString(value, "<sum:(.*)[ ]?\\+.*>");
                    string secondValueToReplace = Strings.GetMatchFromString(value, "<sum:" + firstValueToReplace + "([^>]*)>");

                    decimal d1 = Decimal.Parse(firstValueToReplace);
                    decimal d2 = Decimal.Parse(secondValueToReplace);
                    decimal d3 = d1 + d2;

                    value = value.Replace(matchedText, d3.ToString());
                }

                if (value.Contains("<whitespace>"))
                {
                    value = "      ";
                }
            }
            return value;
        }
    }
}
