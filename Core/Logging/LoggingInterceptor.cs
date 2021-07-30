using Ninject.Extensions.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Logging
{
    public class LoggingInterceptor : SimpleInterceptor
    {
        protected override void BeforeInvoke(IInvocation invocation)
        {
            //Loglama Frameworkünün loglama işlemleri yapılacak
            base.BeforeInvoke(invocation);
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            //Loglama Frameworkünün loglama işlemleri yapılacak
            base.AfterInvoke(invocation);
        }
    }
}
