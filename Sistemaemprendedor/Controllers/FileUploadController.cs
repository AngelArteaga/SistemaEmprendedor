using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Sistemaemprendedor.App_Start;
using System.Configuration;
using System.Text;

namespace Sistemaemprendedor.Controllers
{

      
    public class FileUploadController : Controller
    {
        /// <summary>
        /// Metodo que permite subir al storage un archivo que viene desde un formulario POST
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="filePosted">Archivo de un formulario POST</param>
        /// <returns>Retorna la url del archivo que subio, si existe algun error durante el proceso retorna un string ("ERROR")</returns>
        public string uploadFileIntoBlob(string fileName, HttpPostedFileBase filePosted)
        {
            try
            {
                //desarrollo
                //CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;

                //produccion
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(AppConfig.SE_stg);//se obtiene la configuracion de la conexion al storage
                
                var client = new CloudBlobClient(new Uri(ConfigurationManager.AppSettings["SEBlobUrl"]), storageAccount.Credentials);// se crea un cliente 

                var container = client.GetContainerReference(ConfigurationManager.AppSettings["SE_stgContainer"]);//se abre el contenedor

                // Retrieve reference to a blob named "".
                //var containerPermissions = container.GetPermissions(); // se actualizan los permisos para acceso
                //containerPermissions.PublicAccess = BlobContainerPublicAccessType.Container;
                //container.SetPermissions(containerPermissions);

                var blockBlob = container.GetBlockBlobReference(fileName); // se obtiene un blockblob  en el cual se guardara el archivo (stream)
                //eliminiar imagen previa
               // blockBlob.DeleteIfExists();
                blockBlob.UploadFromStream(filePosted.InputStream);

                return blockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {
                // log Error
                return "ERROR";
            }
        }
        /// <summary>
        /// Sobre carga del metodo que permite subir al storage un archivo generico STREAM
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="file">Archivo generico Stream usado para procesar las imagenes del PDF</param>
        /// <returns>Retorna la url del archivo que subio, si existe algun error durante el proceso retorna un string ("ERROR")</returns>
        public string uploadFileIntoBlob(string fileName, Stream file)
        {
            try
            {
                //desarrollo
                //CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;

                //produccion
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(AppConfig.SE_stg);

                var client = new CloudBlobClient(new Uri(ConfigurationManager.AppSettings["SEBlobUrl"]), storageAccount.Credentials);

                var container = client.GetContainerReference(ConfigurationManager.AppSettings["SE_stgContainer"]);

                // Retrieve reference to a blob named "".
               // var containerPermissions = container.GetPermissions();
                //containerPermissions.PublicAccess = BlobContainerPublicAccessType.Container;
                //container.SetPermissions(containerPermissions);


                var blockBlob = container.GetBlockBlobReference(fileName);


                //eliminiar imagen previa
           //     blockBlob.DeleteIfExists();
                //sube el stream iniciando en la posicion 0
                file.Position = 0;
                using (var fileStream = file)
                {
                    blockBlob.UploadFromStream(fileStream);
                }

                return blockBlob.Uri.ToString();
            }
            catch (Exception ex)
            {
                // log Error
                return "ERROR";
            }
        }
    /// <summary>
    /// Metodo que permite descargar un archivo del storage de azure
    /// </summary>
    /// <param name="blobUri">Recibe como parametro la url del archivo</param>
    /// <returns>Retorna un archivo generico STREAM</returns>
        public Stream downloadBlobAsStream(string blobUri)
        {
            //desarrollo
            //CloudStorageAccount storageAccount = CloudStorageAccount.DevelopmentStorageAccount;

            //produccion
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(AppConfig.SE_stg);

            Stream stream = new MemoryStream();

            var client = storageAccount.CreateCloudBlobClient();
            ICloudBlob blob = client.GetBlobReferenceFromServer(new Uri(blobUri));

            if (blob != null)
                blob.DownloadToStream(stream);

            return stream;
        }

        public String UploadFileAsSteam(String FileName, Stream fileStream, String StorageAccontName, String StorageContainer)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(StorageAccontName);
            // Create the blob client.
            CloudBlobClient blobClient = new CloudBlobClient(new Uri(ConfigurationManager.AppSettings["SEBlobUrl"]), storageAccount.Credentials);
            // Retrieve reference to a previously created container.
            CloudBlobContainer container = blobClient.GetContainerReference(StorageContainer); 
            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(FileName);
            fileStream.Position = 0;
            blockBlob.UploadFromStream(fileStream);

            return blockBlob.Uri.ToString();
        }
    }
}
