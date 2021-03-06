# NCDC Climate Data Wrapper

This is a .net wrapper to the [NCDC Climate Data Online (CDO)](https://www.ncdc.noaa.gov/cdo-web/webservices/v2) api.

You will need an access token. You can request one [here](https://www.ncdc.noaa.gov/cdo-web/token).


## Usage

```
var client = new ClimateDataClient(httpClient, "<your_token>", "<user_agent>")

// Construct a request object for "GHCND" data from the station "GHCND:USC00425837" for dates between 1908-05-01 and 1908-06-01
var dataRequest = new DataRequest("GHCND", new DateTime(1908, 5, 1), new DateTime(1908, 6, 1))
    .WithStations("GHCND:USC00425837");

// Get data
var response = client.GetData(dataRequest);

```

## License

MIT License

Copyright 2021 Jonathon Degn

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
