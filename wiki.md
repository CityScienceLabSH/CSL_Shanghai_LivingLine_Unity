# CSharpScope Template Project 
_____
**Note: For lean version including only [1]Lego scanner and [2]cityIO poster/getter, set to this branch: 
https://github.com/CityScope/CS_CSharpScope_Template/tree/DEVELOPMENT_2018**
_____
## Overview

This is a barebone template project for MIT CityScope development in Unity environment. It provides all necessary components for designing a CS table that can scan, compute, share and project urban related simulations. This project is designed to so that each of the core components could run separately, without others dependency.    
____
# Setup

## Unity

Download [Unity](https://unity3d.com/), clone, run
Branches: master for Template, heatmap for Andorra
___
## Displays & Environment

### Displays
Scene, Display 1 (UI) & Display 2 (3D visualization) should all be active; Display 1 will be the most important for the initial runthrough but might be inactive when play is pressed.

### Environment

Check that all textures are there (e.g. the image when there’s no webcam) and that there are no errors on running script. RenderTextures might cause issues here:

**Webcam texture:** The texture is passed from the keystoned quad holding the live webcam stream to another quad that is used for the scanning via a RenderTexture that the Camera looking at the keystoned quad holds.
**Projection-mapped texture: **This texture is coming from a RenderTexture assigned by a Camera looking at the 3D grid.
____
# Running the Template with Static Image

The first run-through with the image already provided is just to help orient the users with the help of the UI in Display 1:

## Views
We can start with the Camera view showing the image of the grid, then the Scanners view showing the scanner objects with their color assignment, then the Projection view with the output (table) image.
![](https://github.com/RELNO/CSharpScope_TemplateProject/blob/master/docs/Scanning_01.png?raw=true)
## Keystoning
![](https://github.com/RELNO/CSharpScope_TemplateProject/blob/master/docs/KeystoneUI.png?raw=true)
Landing on the Projection view, we can toggle the keystone mode to calibrate the projection quad. We can then test saving & loading the configuration we have, as well as switch to the camera view & keystone that object.

## Scanners 

We can also click on Calibrate Scanners here to modify their size/ placement etc.
![](https://github.com/RELNO/CSharpScope_TemplateProject/blob/master/docs/CameraKeystone_01.png?raw=true)
![](https://github.com/RELNO/CSharpScope_TemplateProject/blob/master/docs/CameraKeystone_02.png?raw=true)

## Using webcam input

Under Webcam Settings, we can choose Use Webcam, which will display extra settings for frame rate and pausing the camera. We can toggle between views in this mode, seeing what happens to scanners, 3D object, etc. 

## Color calibration

We can then click on Calibrate Colors under Color Settings--this is the part where we might need to exit the UI view (Display 1) and start looking at the object in the Scene. To begin, though, we can look at the Scanners or Colors views & see how the colors are sorted.
![](https://github.com/RELNO/CSharpScope_TemplateProject/blob/master/docs/Scanning_02.png?raw=true)
_____
# Color Calibration & Objects in the Scene
![](https://github.com/RELNO/CSharpScope_TemplateProject/blob/master/docs/Color3d_lines.png?raw=true)
![](https://github.com/RELNO/CSharpScope_TemplateProject/blob/master/docs/Color3D_03.png?raw=true)
![](https://github.com/RELNO/CSharpScope_TemplateProject/blob/master/docs/Color3d_01.png?raw=true)

## Finding objects in the Scene

After seeing all the components, we can probably look into where the objects are in the scene & how the functionalities are implemented. The Template project has the following sub-categories:

GridDecoder holds all the scanner objects in two sub-groups: (1) the keystoned surface and (2) the scanners that read this texture. Color calibration, UI items (e.g. sliders, dock), and any grid calibration happens here. To begin calibration, we can click on the ScannersParent object inside the decoder, and then on 3D color space to see the 3D color plot.

[cityIO](cityio.media.mit.edu) holds the objects that interpret the scanned data & create the 3D grid. Controls data source (scanners vs via server) & data sending.
PrjMapping holds a camera and the keystoned surface for the projection-mapped table image, similar to the scanned webcam surface.
UICanvas holds all the UI in Display 1.

Helpers holds extra items such as a scene refresh that is currently unused but could be helpful for auto-restarting the app daily; a view manager that is controlled by the UI; and an event manager that helps the different parts communicate.

We can click on each of these to see what kinds of objects they have.

## Colors in 3D

Then, we can look at the 3D color space object & start calibrating colors by moving the spheres--this might be a little complicated at first, but we can try.
_____
# Example: Andorra


Setup: checking out the heatmap branch & making sure nothing’s missing.
We can check how cityIO can work without the other components & how data sending works.
_____
# Implementation Details

CityScope LivingLine Program Spefcification

1.Software environment

PC:Windows/MAC
Unity:2017.4.0f
VisualStudio 2015

2. Directory structure
	 
Folder “Art”: All the model and texture in this folder, except need load source in “Resources” folder;
Folder “GridDecoderAssets”: The Old CityScope source in the git;
Folder “Plugins”: Two plugins in this folder;
	1.“JsonDotNet”: Parse json to c# object.
	2.”SingletonT”: singleton pattern plugin. 
Folder “ProjMapAssets”:Include projMap material and renderTexture;
Folder “Resource”:Need load source;
	1.”Pic”:Building Icon.
	2.”Grid”:the scanner grid prefab.
Folder “Scripts”:All the script in this Folder;
Folder “Settings”: the config json file in this Folder;
	1.”building_list”:building ID setting and it’s connect buildingID
	2.” Dock_0”, ” Dock_1”: when special dock with LEGO, other dock show this config color.
Scene “CSharpScopeTemplate”:We start with this scene.



# Usage Guideline

	1.Double click Scene “CSharpScopeTemplate”.

	2.Pressed Play Button.
	
	3.1.Drop down Menu: Select the last “Maskers View”.
	3.2.Select Use webcam then the screen will show the camera view.
	3.3.Building Grid .when it have purple means selected.Press “Create” button to create gird(5).
	3.4.ShowTable:If selected , all the building grid will become yellow color.It’s because we can easy calibration grid location information.
	3.5.When we click “Create” button. Then click screen , We can create buiding grid at this position.
	3.6.When Selected a building grid, we can click Delet button to delet it.
	3.7.When Selected a building grid, we can drag the Scale slider to scale the grid size.
	3.8.Buildingindex is necessary for all the building grid.

	4.When all the building grids have been added and their positions are all right, it’s Done.

	5.Final we need adjust the light, make all the grid can be scanned correct.


____
TBD: More in-depth look at scanning, adding UI elements (physical UI), maybe cityIO, and discussing what still needs an update (e.g. heatmaps).

# Questions & Suggestions

