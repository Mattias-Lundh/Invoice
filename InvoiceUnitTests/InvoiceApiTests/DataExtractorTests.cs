using Xunit;
using InvoiceAPI.Tools;
using InvoiceUnitTests.Builders.InvoiceApiTestBuilders;
using Newtonsoft.Json;

namespace InvoiceUnitTests.InvoiceApiTests
{
    public class DataExtractorTests
    {
        public DataExtractorTests()
        {
            // arrange
            sut = new DataExtractor();
        }

        private IDataExtractor sut;

        [Fact]
        public void ExtractInvoiceParamsAsJson_GivenValidArray_ReturnsJsonString()
        {
            // arrange
            string[] inputParameter = new string[38];
            inputParameter[2] = "some street 123";
            inputParameter[0] = "avi: 12345678";
            inputParameter[37] = "amount due: 300,05 ";

            var pdfDataAvi = new PdfDataBuilder();
            pdfDataAvi
                .SetAddress("some street 123")
                .SetAvi(12345678)
                .SetAmountDue(300.05);
            string expectedResult = JsonConvert.SerializeObject(pdfDataAvi);

            // act
            var result = sut.ExtractInvoiceParamsAsJson(inputParameter);

            // assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ExtractInvoiceParamsAsJson_GivenEmptyArray_ReturnsDefaultedJsonString()
        {
            // arrange
            string[] inputParameter = new string[0];
            string expectedResult = JsonConvert.SerializeObject(new PdfDataBuilder());

            // act
            var result = sut.ExtractInvoiceParamsAsJson(inputParameter);
            
            // assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ExtractInvoiceParamsAsJson_GivenArrayWithUnrecognizedformat_ReturnsIncompleteJsonString()
        {
            // arrange
            // avi
            string[] inputParameterWithUnrecognizedAvi = new string[38];
            inputParameterWithUnrecognizedAvi[2] = "mock Address";
            inputParameterWithUnrecognizedAvi[0] = "this contains no numbers";
            inputParameterWithUnrecognizedAvi[37] = "this will work 300,05 !";

            var pdfDataAvi = new PdfDataBuilder();
            pdfDataAvi
                .SetAddress("mock Address")
                .SetAvi(default(int))
                .SetAmountDue(300.05);
            string expectedResultAvi = JsonConvert.SerializeObject(pdfDataAvi);

            // amountDue
            string[] inputParameterWithUnrecognizedamountDue = new string[38];
            inputParameterWithUnrecognizedamountDue[2] = "mock Address";
            inputParameterWithUnrecognizedamountDue[0] = "12345678";
            inputParameterWithUnrecognizedamountDue[37] = "this will not work!";

            var pdfDataAmountDue = new PdfDataBuilder();
            pdfDataAmountDue
                .SetAddress("mock Address")
                .SetAvi(12345678)
                .SetAmountDue(default(double));
            string expectedResultAmountDue = JsonConvert.SerializeObject(pdfDataAmountDue);

            // act
            var resultAvi = sut.ExtractInvoiceParamsAsJson(inputParameterWithUnrecognizedAvi);
            var resultAmountDue = sut.ExtractInvoiceParamsAsJson(inputParameterWithUnrecognizedamountDue);

            // assert
            Assert.Equal(expectedResultAvi, resultAvi);
            Assert.Equal(expectedResultAmountDue, resultAmountDue);
        }
    }
}
