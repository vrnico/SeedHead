SeedHead
==========
#### A .Net Application by Nico Daunt

### Epicodus Weeks One and Two .Net Code Review on Typescript and Angular.

#### Description
SeedHead is a community resource for gardeners and farmers of all sorts. Our goal is to connect growers with the seeds they need, and to provide an interface for seed collectors to share their stash!
***
[VISIT THE LIVE DEMO](https://google.com)
***

## Installation (build your own database!)

#### this setup assumes previous installation of MAMP and Microsoft Visual Studio



Open your preferred terminal, and enter the following command to clone source to your local machine:
```sh
https://github.com/vrnico/SeedHead
```

navigate to the SeedHead directory:
```sh
cd SeedHead
```

restore your dotnet project:
```sh
dotnet restore
```

Generate the database
```
$dotnet ef migrations add Initial
$dotnet ef database update
```
Run program from Visual Studio by pressing ctrl F5 or the play button


Enjoy your brand new SeedHead Database!



## Specifications

1. #### Takes a users input as a seed.

| Input      | Output           |
| ------------- |:-------------:|
| Amaranth, Plant with the spring or summer rains. Broadcast or rake the tiny seeds, covering with 1/4 inch of soil., 40 parcels Left    | **Amaranth, Plant with the spring or summer rains. Broadcast or rake the tiny seeds, covering with 1/4 inch of soil., 40 parcels Left** |


2. #### Takes a users input as an Offer Zone Profile

| Input      | Output           |
| ------------- |:-------------:|
| Gardener DIY Warehouse      | **Gardener DIY Warehouse** |

3. #### References Seeds to respective Offer Zones

| Input      | Output           |
| ------------- |:-------------:|
| Gardener DIY House    | **There are 8 different crops available at this Offer Zone** |




## features
1. Add your seeds
2. Add your offer zones
3. Delete Seeds
4. Delete Offer Zones








## Created With
* HTML
* Bootstrap
* CSS
* .NET
* Moq
* MySQL




## Contact
questions/comments/concerns
* [nico.daunt@gmail.com](mailto:nico.daunt@gmail.com)
* [PERSONAL WEBSITE](nicodaunt.com)




## License
Copyright 2018

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.