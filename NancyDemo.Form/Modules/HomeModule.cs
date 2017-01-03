using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace NancyDemo.Form
{   
    public class HomeModule:NancyModule
    {
        public HomeModule()
        {
            //旧方法：jQuery和PHP提交表单
            Get["/"] = x =>
            {
                
                return this.View["index-old"];
            };

            //新方法：AngularJS和PHP提交表单
            Get["/new"] = x =>
            {

                return this.View["index-new"];
            };

            //统一后台处理
            Post["/submit"] = x =>
            {   

                Dictionary<string, object> errors = new Dictionary<string, object>();
                Dictionary<string, object> data = new Dictionary<string, object>();

                if (string.IsNullOrWhiteSpace(this.Request.Form.name))
                    errors.Add("name", "Name is required.");
                
                if (string.IsNullOrWhiteSpace(this.Request.Form.superheroAlias))
                    errors.Add("superheroAlias", "Superhero alias is required.");

                if (errors.Count > 0)
                {
                    data.Add("success", false);
                    data.Add("errors", errors);
                }
                else
                {
                    data.Add("success", true);
                    data.Add("message", "Success!");  
                }
                
                return this.Response.AsJson<object>(data);
            };
        }
    }
}