using Plugin.Media;
using Plugin.Media.Abstractions;

namespace MasterTechParallelMAUI.Views.Translate
{
    public partial class TranslatePage : ContentPage
    {
        public TranslatePage()
        {
            InitializeComponent();
        }

        // Handle the "Take Picture" button click event
        private async void OnTakePictureClicked(object sender, EventArgs e)
        {
            // Request runtime permissions for camera and storage
            var cameraStatus = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (cameraStatus != PermissionStatus.Granted)
            {
                cameraStatus = await Permissions.RequestAsync<Permissions.Camera>();
            }

            var storageStatus = await Permissions.CheckStatusAsync<Permissions.StorageRead>();
            if (storageStatus != PermissionStatus.Granted)
            {
                storageStatus = await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            // Check if the permissions are granted before proceeding
            if (cameraStatus == PermissionStatus.Granted && storageStatus == PermissionStatus.Granted)
            {
                try
                {
                    // Initialize the media plugin and check if the camera is available
                    await CrossMedia.Current.Initialize();

                    if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                    {
                        await DisplayAlert("No Camera", "Camera is not available.", "OK");
                        return;
                    }

                    // Take a photo with the camera
                    var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                    {
                        SaveToAlbum = true, // Optionally save the image to the photo album
                        PhotoSize = PhotoSize.Small, // Adjust photo size
                        CompressionQuality = 92 // Set the image quality
                    });

                    if (photo != null)
                    {
                        // Display the captured photo in the UI (e.g., show it in an 'Image' control)
                        cameraImage.Source = ImageSource.FromStream(() => photo.GetStream());
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors during camera use
                    await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
                }
            }
            else
            {
                // Permissions were not granted
                await DisplayAlert("Permissions Denied", "We need camera and storage permissions to take a picture.", "OK");
            }
        }
    }
}
