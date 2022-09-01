using UnityEngine;

public class FileManagerHandler : MonoBehaviour
{
    public FileManager FileManager { get; private set; }
    private string _generalFilePath = "������ ������.txt";
    private string _removedFilePath = "�������.txt";
    private string _tagsFilePath = "������ �����.txt";

    private void Awake()
    {
        _generalFilePath = Application.persistentDataPath + '/' + _generalFilePath;
        _removedFilePath = Application.persistentDataPath + '/' + _removedFilePath;
        _tagsFilePath = Application.persistentDataPath + '/' + _tagsFilePath;
        FileIO fileIO = new FileIO();
        FileManager = new FileManager(fileIO, _generalFilePath, _removedFilePath, _tagsFilePath);
    }
}
