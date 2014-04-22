using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace Element.Sigma.Common.Param
{
    public class ValidationParameterInspector : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            if (operationName == "GetData")
            {
                for (int index = 0; index < outputs.Length; index++)
                {
                    if (index == 0)
                    {
                        // execute the method level validators
                        if (((int)outputs[index] < 0) || ((int)outputs[index] > 5))
                            throw new FaultException("Your Error Message");
                    }
                }
            }
        }

        public object BeforeCall(string operationName, object[] inputs)
        {

            if (operationName == "GetData")
            {

                for (int index = 0; index < inputs.Length; index++)
                {
                    if (index == 0)
                    {
                        // execute the method level validators
                        if (((int)inputs[index] < 0) || ((int)inputs[index] > 5))
                            throw new FaultException("Validation Input  Error");
                    }

                }

            }

            return null;
        }
    }
}
