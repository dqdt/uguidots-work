# Taking notes here.

# 5/5/2020

Unity UI: also called UGUI. The name is com.unity.ugui.
* Why does the namespace(?) begin with "com"? 
* https://softwareengineering.stackexchange.com/questions/180353/why-do-so-many-namespaces-start-with-com
  * Reverse domain notation.

What is UGUIDots?
* A bridge between Unity's default UI and ECS (make it more data-oriented).
* The workflow of authoring UI elements should be the same (?).

Dependencies:
* Burst, Entities, Jobs, Collections, UGUI, Univeral RP, TextMeshPro.

Contributing:
* Fork the repo. 
  * Master branch for pending bugs. Develop branch for features.
* Push to your forked repo.
  * Pull request to the master branch.
    * Include a summary of changes in CHANGELOG.md.
  * Pull request to the develop branch if you have a feature.
Tips:
* Ensure your git commits are easy to follow and read.
* Follow the C# MSDN Conventions.

UGUIDots.Samples
* git clone [url] --recursive
  * https://explainshell.com/explain?cmd=git+clone+--recursive
  * After the clone is created, initialize all submodules within, using their default settings. This is equivalent to running `git submodule update --init --recursive` immediately after the clone is finished.
* UGUIDots.Samples includes UGUIDots as a submodule...
* Error: no private key
  * It works in Git Bash, but not Powershell/etc.
  * I don't have a ssh key for the other terminals?
  * https://help.github.com/en/github/authenticating-to-github/error-permission-denied-publickey#should-the-sudo-command-be-used-with-git
  * Just use Git Bash / Github Desktop for now...

OK, I figure I should have my own project, with a structure similar to UGUIDots.Samples.
* Private repo "uguidots-work" containing a unity project.
* Add my forked UGUIDots as a submodule in the Assets folder.
  * I should add a second remote: the main UGUIDots repo, named "origin2".
    * Now we can fetch changes from the main UGUIDots repo.
    * Pulling from the main repo? I rebased master onto origin2/master, and pulled the changes.
* Side note:
  * https://stackoverflow.com/questions/2883840/differences-between-git-pull-origin-master-git-pull-origin-master
    * `git pull origin master`: pulls from the `origin` remote, `master` branch
    * `git pull origin/master`: pulls from the locally stored branch `origin/master`
      * `origin/master` is a "cached copy" of what was last pulled from origin

I'm trying to open up the UGUIDots.Samples project in Unity, but it is stuck at "Resolving Packages".
* Just wait longer.

# 5/6/2020 - 5/8/2020

https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html

### Notes on Unity UI docs:
* A UI toolkit for developing UI for games and applications.
* GameObject-based UI system that uses Components and the Game View to arrange, position, and style user interfaces.
* The documentation describes creating a Canvas, positioning and animating elements, defining user interactions.

### Canvas
* The Canvas is an area that all UI elements should be inside.
* The Canvas is a GameObject with a Canvas component.
  * All UI elements must be children of a Canvas.
* Creating a new UI element (e.g. GameObject > UI > Image) when there is no existing Canvas in the scene will automatically create a Canvas and attach the new element as a child of the Canvas.
* A Canvas needs an EventSystem.
* The Canvas area is a rectangle in the Scene View.
  * Allows working outside the Game View.
* Draw order
  * UI elements are drawn in the same order as they appear in the Hierarchy.
    * Drag elements to change the draw order.
    * To change the order in scripts, use these methods on the transform component: SetAs(First|Last)Sibling, SetSiblingIndex.
* Render Mode
  * The canvas has a Render Mode setting to make it render in screen space or world space.
  * Screen Space - Overlay
    * Renders on top of the scene.
    * If the screen is resized or changes resolution, the Canvas will automatically resize.
  * Screen Space - Camera
    * The Canvas is placed a given distance in front of a specified Camera. The UI elements are rendered by this camera.
  * World Space
    * The Canvas will behave as any other object in the scene.
    * Position the Canvas through its Rect Transform.
    * UIs that are a part of the world. This is known as a "diegetic interface".
      * https://gamedev.stackexchange.com/questions/99246/what-are-diegetic-non-diegetic-spatial-and-meta-user-interfaces
        * "diegetic" means it's part of the scene; visible to the main character.
        * "non-diegetic" means it's not part of the scene.
      * https://en.wikipedia.org/wiki/Diegesis
        * The narrator tells the story: the details of the world and the experiences of the characters.
        * There is a presumed detachment from the story from the speaker and the audience.
        * diegesis: to narrate
        * non-diegetic elements: _how_ the narrator tells the story

### Basic Layout
* Every UI element is a rectangle for layout purposes.
  * Use the Rect Tool in the Scene View to manipulate the rectangle.
    * Move by dragging.
    * Resize by dragging the corners.
    * Rotate by hovering around the corner until the cursor changes, then drag.
      * Pivot point: Center of rectangle, or Pivot (manual).
      * Local/Global space: Tool handles are in the active object's rotation, or global rotation (??).
    * The Rect Tool is used for Unity2D features, UI, and even 3D objects.
* Rect Transform
  * Used instead of the regular Transform component.
  * Position, Rotation, Scale, Width, Height
    * Rect Tool only changes the position, width, and height.
  * Pivot
    * Shown as a blue ring.
    * Rotations, size, and scale modifications occur around the pivot.
  * Anchor
    * Shown as four triangles.
    * Hold down Shift when dragging an anchor to also move the corresponding corner of the rectangle.
    * Anchor presets.
    * What's the math behind it? We'll see...

### Visual Components
* Text
* Image
  * Source Image: Sprite
  * Color
  * Material
  * Image Type
    * Simple: Scale the whole sprite equally.
    * Sliced: 3x3 sprite division. (9-slicing?) Stretches the center part.
    * Tiled: Repeats the center part rather than stretching it.
    * Filled: Fills only a certain amount.
  * Images can be imported as UI sprites? Sprite editor.
* Raw Image
  * Takes a texture. No borders.
* Mask
  * Restricts the child elements to the shape of the parent.
* Effects
  * e.g. Shadow or outline.
  * See UI Effects page.

### Interaction Components
* Most of the interaction components are "selectables", which means they have built-in functionality for visualising transitions between states (normal, highlighted, pressed, disabled) and navigation to other selectables using a keyboard or controller.
* At least one UnityEvent is invoked when the user interacts with the component in a specific way.
  * The UI system catches and logs any exceptions that propagate out of a UnityEvent.
* Button
  * OnClick
* Toggle (Checkbox)
  * OnValueChanged
* Toggle Group (Mutually exclusive toggles)
* Slider
  * OnValueChanged
* Scrollbar
  * OnValueChanged
  * Handle size as a fraction of the entire scrollbar length.
* Dropdown
  * OnValueChanged
* Input Field
  * Editable text element
* Scroll Rect (Scroll View)
  * Scrollable content inside a window.
  * A Scroll Rect provides functionality to scroll over a rectangle.
  * A Scroll Rect is usually combined with a Mask and Scrollbars to create a Scroll View.

### Animation Integration
* Animate transitions between control states using Unity's animation system.
* On the controller element (e.g. Button, Slider), select Transition: Animation, and click "Auto Generate Animation". This generates an Animator Controller with the state diagram already set up (save the .controller file), and attaches an Animator component. We can move from any state to any other state. Usually, the transition animation is a keyframe at the start of the timeline. 
* Ex: make the button grow when entering the Highlighted state.
  * Several buttons can share the same animator controller.
* The UI Animation transition mode is not compatible with Unity's legacy animation system.

### Auto Layout
* Nested layout groups such as horizontal/vertical groups and grids.
* The auto layout system is based on a concept of layout element and layout controllers.
* Layout Element
  * A GameObject with a Rect Transform.
  * Contains: Minimum width/height, Preferred width/height, Flexible width/height.
  * Starts out with sizes of 0. Components will change the sizes, e.g. Image and Text will have the preferred size match the content.
  * You can override the sizes with a Layout Element Component.
  * Layout controller uses info in layout elements to calculate a size for them. A layout group will do this:
    1) First, minimum sizes are allocated.
    2) If there is sufficient available space, preferred sizes are allocated.
    3) If there is additional available space, flexible size is allocated. (??)
* Layout Controller
  * Content Size Fitter
    * Controls the size of its own layout element.
  * Aspect Ratio Fitter
    * Width controls Height (or vice versa), Fit in Parent, Envelope Parent
  * Layout Groups
    * Controls the sizes and positions of its child layout elements.
    * Does not control its own size.
    * A Rect Transform may have **driven properties** which appear as read-only, meaning they are driven by a layout controller.
      * Driven properties are not saved as part of the scene, as changing things manually would. This is good because resizing can happen often (e.g. resizing the game view window).
* Layout Interfaces
  * ILayoutElement: Can be treated as a layout element by the auto layout system.
  * ILayoutGroup: Is expected to drive Rect Transforms of its children.
  * ILayoutSelfController: Is expected to drive its own Rect Transform.
* Layout Calculations
  * Calculate minimum/preferred/flexible widths, bottom-up. This is so parents can take into account information in their children.
  * The effective widths of layout elements are calculated top-down. The allocation of child widths needs to be based on the full width available to the parent.
  * Repeat for heights. The calculated heights may depend on the widths, but not vice versa...
* Triggering Layout Rebuild
  * LayoutRebuilder.MarkLayoutForRebuild(transform as RectTransform)
  * Happens at the end of the current frame, just before rendering happens.
  
### Rich Text
* The text for UI elements and text meshes can incorporate multiple font styles and sizes. The Rich Text setting instructs Unity to look for markup tags within the text. Debug.Log() can also include these markup tags to enhance error reports.
  * bold, italic, size, color
  * material: Give a value that is an index into the text mesh's array of materials as shown in the inspector.
  * quad: Renders an image inline with the text.

### Event System
* The Event System itself is designed to be a manager of communication between Event System modules.
* The Event System is a way of sending events to objects in the application based on input.
  * Manage which GameObject is considered selected
  * Manage which Input Module is in use
  * Manage Raycasting (if required) ??
  * Updating all Input Modules as required
* Input Modules contain the logic for how you want the Event System to behave.
  * Handling Input
  * Managing event state
  * Sending events to scene objects
* The Input Module must be a component on the same GameObject as the Event System.
* Only one Input Module can be active in the Event System at a time.
* Raycasters are used by Input Modules for figuring out what the pointer is over.
  * Graphics Raycaster: Used for UI elements, searches within the Canvas
  * Physics 2D Raycaster: Used for 2D physics elements
  * Physics Raycaster: Used for 3d physics elements
* If you have a 2D/3D raycaster in your scene, it is easy to make non-UI elements receive messages from the Input module. Simply attach a script that implements one of the event interfaces (IPointerEnterHandler, IPointerClickHandler).
  
### Messaging System
* Replaces the old "SendMessage" ??
* Make a class that extends MonoBehaviour and IEventSystemHandler, so that this can be a target for receiving events.
* There is a static helper class that executes the functor (?) in the interface.
* The call is made on a speficied GameObject, and is issued to all components of the GameObject that implement the interface.
  * You can control:
    * What data is passed.
    * How far down the GameObject heirarchy the event should propagate (parents and children).
* This framework also allows you to search and find GameObjects that implement a given messaging interface.

### Input Modules
* When the Event System is enabled, it looks at what Input Modules are attached and passes update handling to the specific module.
* The purpose is to map hardware-specific input into events that are sent via the messaging system.
* Out of the box, there are two provided Input Modules: one Standalone, and one for Touch input.

### Supported Events
* IPointer(Enter|Exit|Down|Up|Click)Handler
* I(InitializePotentialDrag|BeginDrag|Drag|EndDrag|Drop)Handler
* I(Scroll)Handler
* I(UpdateSelected|Select|Deselect)Handler
* I(Move)Handler
* I(Submit|Cancel)Handler

### Raycasters
* Given a screen space position, collect all potential targets and figure out if they are under the given position, and return the object that is closest to the screen.
* When a Raycaster is present and enabled in the scenee, it will be used by the Event System for every query. If multuple Raycasters are used, they they will all be used, and the results will be sorted by distance.

### UI How-Tos
* For later -- might be useful to know...
* Designing UI for Multiple Resolutions
* Making UI elements fit the size of their content
* Creating a World Space UI
* Creating UI elements from scripting
* Creating Screen Transitions

# 5/11/2020

### UGUIDots Wiki

### Canvas
* A Canvas is an entity which contains a dynamic buffer of children entities.
* The primary role of the Canvas is to manage the scaling of UI elements so that they at a proper size regardless of screen size.
* Canvas Converstion System
  * All canvases that are in a subscene or have a `ConvertToEntity` trigger can have the following components attached:
    * RootVertexData, RootTraingleIndexElement, RenderElement, BatchedSpanElement, SubMeshKeyElement, SubMeshSliceElement, Child, CanvasSortOrder, WidthHeightRatio, BatchCanvasTag, BuildCanvasTag, AddMeshTag, MaterialPropertyBatch
    * Ugh, a list without context...
* Building the Canvas:
  1) Child entities must be marked to be built.
    * `Build(Image|Text)VertexDataSystem` will run on entities with a `BuildUIElementTag`. This causes local vertex data to be built. These systems will recurse to the root canvas and mark it with `BatchCanvasTag`, indicating that the canvas has to consolidate all the children.
  2) Canvases having the `BatchCanvasTag` will recurse through its children and build the `RootVertexData` and `RootTriangleIndexElement` by consolidating its children's local vertices.
    * The canvas is then marked with `BuildCanvasTag`, indicating that it should be built.
  3) Canvases having the `BuildCanvasTag` have their `RootVertexData` and `RootTriangleDataElement` copied into its associated Mesh.
  4) The `BatchedCanvasTag` (?) is then removed from the Canvas and the mesh is prepared for rendering.
* Note on Rendering:
  * Similar to UGUI, canvases are typically the primary renderers. Children of the Canvas should pass render information to the Canvas.
    * e.g. Images and text components are not renderers, but are suppliers of vertex and index information to the Canvas.
  * Note: The way we're doing it is more efficient than (???). We can store many canvases into a particular chunk, along with its mesh data. This allows a single archetype to be queried and read, simply by iterating on the chunks. This is better than than jumping between archetypes.
  * ???
    * The Canvas has a managed Mesh component. The `AddMeshSystem` finds all canvas archetypes, consumes the `AddMeshTag`, and then adds the managed Mesh to the Canvas...?
* Note on Batching:
  * Batching allows meshes with the same material and texture to be constructed together and issued with a single draw call. Meshes are made up of submeshes. This is similar to Unity's default UI system.
    * To see how meshes and submeshes are built and batched together, see `(Batch|Build)CanvasMeshSystem`.
  * Like Unity's UI, canvases are batched on editor time, and this information is stored on the root canvas. Without specifying a batch, the canvas will not render. The `BatchedMeshAuthoring` component is responsible for building the mesh. (This is a component for a GameObject?)
    * This component contains a list of batches.
    * In each batch, theres a list of elements (images?)
    * There is a `Build Batch` button.
* Recomputing the Canvas
  * Generally, only rebuild the canvas when new elements are added to the UI, or the screen resolution changes.
  * When the screen resolution changes, an entity with `ResolutionChangeEvt` component is produced. This causes `AnchorSystem` and `CanvasScalerSystem` to run.

### Image
* Currently, the only image type supported are Image components that have a fill type **Simple**.
* The `ImageConversionSystem` crates an entity and attaches these components:
  * Linked(Material|Texture)Entity, AppliedColor, Dimensions, DefaultSpriteResolution, SpriteData, MeshVertexData, TriangleIndexElement, MeshDataSpan, BuildUIElementTag, UpdateVertexColorTag, MaterialPropertyIndex
* DefaultSpriteResolution
  * We need to know the original sprite resolution to do scaling, so the image looks the same in Editor time and in runtime.
* Storing Mesh data
  * The `Local(VertexData|TriangleIndex)Element` buffers contain the mesh data.
  * Images are quads. The `BuildImageVertexData` builds the mesh.
* "Texture Entities"
  * Textures are stored on their own entities as a ComponentObject. These entities are linked to Image entities via the `VisualAssetConversionSysten` and declated in the `VisualAssetDeclarationSystem`. ???

### Text
* Currently only supports TextMeshPro, because they have a generated font atlas, so it was easier to just figure out how to scale the text to match its point size (?).
  * UGUI Text components are not supported, due to its reliance on the FontEngine (?) and needing to sample the actual point sizes on runtime.
* Conversion Pipeline
  * FontAssetDeclarationSystem
    * Declares that the TMP FontAsset's ScriptableObject to be represented as an entity.
  * FontAssetConversionSystem
    * Grabs all of the embedded FontAssets from TextMeshProUGUI and adds these components:
      * FontID, GlyphElement, FontFaceInfo
  * TMPTextConversionSystem
    * Grabs all TextMeshProUGUIs and adds these components:
      * Dimensions, TextFontID, TextOptions, CharElement, Local(VertexData|TriangleIndex)Element, LinkedMaterialEntity, MeshDataSpan, AppliedColor, BuildUIElementTag, MaterialPropertyIndex
* Storing Mesh data
  * All letters of a mesh are built to the same vertex buffer; this batches it into one draw call.
  * Each letter's glyph is retrieved from the FontAsset entity, and the glyph metrics (?) are applied to build the quad.
  * Font scaling so that larger point sizes match the editor time representation.
  * See: https://learnopengl.com/In-Practice/Text-Rendering.

### Rendering
* Orthographic Render Pass
  * To support the Universal Render Pipeline (URP), a custom render pass has been built, whose sole purpose is to do orthographic projection.
* OrthographicMeshRenderSystem
  * Happens every render frame:
  * Retrieve the OrthographicRenderFeature via RenderCommandProxy.
  * For each Canvas, retrieve its mesh and push the mesh to the InstructionQueue in the OrthographicRenderPass.
  * The OrthographicRenderPass flushes the InstructionQueue and executes the GraphicsCommandBuffer in orthographic view.
* Limitations:
  * There is no way to add multiple GraphicsCommandBuffer, as multiple command buffers would mean parallel context execution on the render side. (???)

### Shaders
* UGUIDOTS provides specialized materials to handle Translation and FillAmount.
* Default UI Material
  * The Default UI Material works in the URP, but the limitation is that the transformation matrix has to be updated in the mesh.
  * If a UI element has to move, we can copy the translation to the shader.
* Material Property Index
  * All Images/Text have a MaterialPropertyIndex component to access the MaterialPropertyBatch in the root canvas.
* DefaultImage Material
  * DefaultImage is similar to the DefaultUI material, except it allows for translation and fill.
  * Examples: UIPingPongSystem and HeartFillSystem in the UGUIDots.Samples
  * Translation:
    * Pass a Vector4 to the Translation property. The translation is in local space?
  * Fill:
    * Pass a float to the FillAmount property.
* The `ShaderConstants` static class contains properties that are supported.
* Limitations
  * Canvas Rebuild
    * If you have a continuously moving element in your UI, and you schedule a Canvas rebuild, the original transformation is not properly resetted. This creates an offset effect ??
  * Batching
    * Each material property is associated with a collection of elements.
    * Imagine a canvas with 3 batches. Each batch has properties that are common to all things in the batch.
    * So if you need to update UI elements individually, the recommended way is to separate the elements from the batch. The HeartFillSystem does this if you inspect the # of batches in the Fill Canvas ??

### Material
* Materials are declared their own entities by the `VisualAssetDeclarationSystem`, which loops through all Image and TextMeshProUGUI components.
* Other entities using a material will have LinkedMaterialEntity components.

### Button
* Buttons are supported but in a verbose way. Currently experimental.
* Setup:
  * If you want text with your button, use the TextMeshPro button.
  * To mark a button, add these to the GameObject:
    * ButtonTypeAuthoring
    * Button Behavior Script
    * ButtonFrameMessagePayload
* Workflow
  * ButtonTypeAuthoring
    * Defines what type of button it is:
      * ReleaseUp, PressDown, Held
  * Button Behavior Script
    * UGUIDOTS does not have its own native event system, so it uses a Producer/Consumer model.
    * Must define an entity to produce during the click.
      * This produced entity is processed on the following frame, and consumed on the next frame, in the `PresentationCommandBufferSystem`.
    * Example:
      ```csharp
      ID: IComponentData {public int Value;}
      Convert(entity, dstManager, conversionSystem) {
        var ent1 = dstManager.CreateEntity();
        dstManager.AddComponentData(ent1, new ID {Value = 1});
        dstManager.AddComponentData(entity, new ButtonMessageFramePayload {Value = ent1});
      }
      ```
      * We create an "messaging entity" and add components (ID). Then this entity is enclosed in a ButtonMessageFramePayload. This allows the ButtonMessageProducerSystem to read the entity and create a copy of it, so other systems can read it when they update.
  * So the workflow is as follows:
    * Click on button.
    * Produce a messaging entity.
    * Process messaging entity to do some action.
    * Consume messaging entity.
  * Message Groups
    * MessagingProductionGroup
      * Where the ButtonMessageProducerSystem creates the messaging entity.
    * MessagingConsumptionGroup
      * Where the ButtonMessageConsumerSystem destroys the messaging entity.
    * MessagingUpdateGroup
      * Where systems process the messaging entity (i.e. update).