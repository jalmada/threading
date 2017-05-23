using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace threading
{
    public static class Parser
    {

        public static List<XDto> ToXDto(IEnumerable<XElement> xElements){
            var dtos = new List<XDto>();

            foreach(var el in xElements){
                
                var elementDto = new XDto{
                    ElementType = el.NodeType.ToString(),
                    TagName = el.Name.LocalName,
                    Value = string.Empty,
                };
            

                if(el.HasAttributes){ 
                foreach(var attr in el.Attributes()){
                        elementDto.Children.Add(new XDto {
                            ElementType = attr.NodeType.ToString(),
                            TagName = attr.Name.LocalName,
                            Value = attr.Value
                        });
                    }
                }

                if(el.HasElements){
                    elementDto.Children.AddRange(ToXDto(el.Elements()));
                }

                dtos.Add(elementDto);
            }

            return dtos;
        }

        public static XDto ToXDto(XElement element){

            var elementDto = new XDto {
                ElementType = element.NodeType.ToString(),
                TagName = element.Name.LocalName,
                Value = string.Empty
            };

            var childrenCount = element.Elements().Count();
            var chunckSize = 500;
            var countLastChunk = childrenCount % chunckSize;
            var numChunks = Decimal.ToInt32(Math.Floor((decimal)(childrenCount/chunckSize)));
            numChunks = numChunks + (countLastChunk > 0 ? 1 : 0);

            var tasks = new Task[numChunks];

            for(var chunckNum = 0; chunckNum < numChunks; chunckNum++){
                tasks[chunckNum] = Task.Factory.StartNew(() =>  {
                    return ToXDto(element.Elements().Skip(chunckNum * chunckSize).Take(chunckSize).ToList());
                });
            }

            Task.WaitAll(tasks);
           

            //elementDto.Children.AddRange(bag);
            return elementDto;
        }
    }
}