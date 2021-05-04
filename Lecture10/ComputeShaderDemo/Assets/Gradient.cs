using UnityEngine;

public class Gradient : MonoBehaviour
{
    public GameObject _objectA;
    public GameObject _objectB;
    public ComputeShader _computeShader;

    private RenderTexture _renderTextureA;
    private RenderTexture _renderTextureB;

    private int _kernelIndex_KernelFunction_A;
    private int _kernelIndex_KernelFunction_B;

    private struct ThreadSize
    {
        public int X;
        public int Y;
        public int Z;

        public ThreadSize(uint x, uint y, uint z)
        {
            X = (int)x;
            Y = (int)y;
            Z = (int)z;
        }
    }

    private ThreadSize _kernelThreadSize_KernelFunction_A;
    private ThreadSize _kernelThreadSize_KernelFunction_B;

    private void Start()
    {
        _renderTextureA = new RenderTexture(512, 512, 0, RenderTextureFormat.ARGB32);
        _renderTextureB = new RenderTexture(512, 512, 0, RenderTextureFormat.ARGB32);

        _renderTextureA.enableRandomWrite = true;
        _renderTextureB.enableRandomWrite = true;

        _renderTextureA.Create();
        _renderTextureB.Create();

        _kernelIndex_KernelFunction_A = _computeShader.FindKernel("KernelFunction_A");
        _kernelIndex_KernelFunction_B = _computeShader.FindKernel("KernelFunction_B");

        uint threadSizeX, threadSizeY, threadSizeZ;

        _computeShader.GetKernelThreadGroupSizes(
            _kernelIndex_KernelFunction_A, out threadSizeX, out threadSizeY, out threadSizeZ);

        _kernelThreadSize_KernelFunction_A = new ThreadSize(threadSizeX, threadSizeY, threadSizeZ);

        _computeShader.GetKernelThreadGroupSizes(
            _kernelIndex_KernelFunction_B, out threadSizeX, out threadSizeY, out threadSizeZ);

        _kernelThreadSize_KernelFunction_B = new ThreadSize(threadSizeX, threadSizeY, threadSizeZ);

        _computeShader.SetTexture(_kernelIndex_KernelFunction_A, "textureBuffer", _renderTextureA);
        _computeShader.SetTexture(_kernelIndex_KernelFunction_B, "textureBuffer", _renderTextureB);
    }

    private void Update()
    {
        _computeShader.Dispatch(
            _kernelIndex_KernelFunction_A,
            _renderTextureA.width / _kernelThreadSize_KernelFunction_A.X,
            _renderTextureA.height / _kernelThreadSize_KernelFunction_A.Y,
            _kernelThreadSize_KernelFunction_A.Z);

        _computeShader.Dispatch(
            _kernelIndex_KernelFunction_B,
            _renderTextureB.width / _kernelThreadSize_KernelFunction_B.X,
            _renderTextureB.height / _kernelThreadSize_KernelFunction_B.Y,
            _kernelThreadSize_KernelFunction_B.Z);

        _objectA.GetComponent<Renderer>().material.mainTexture = _renderTextureA;
        _objectB.GetComponent<Renderer>().material.mainTexture = _renderTextureB;
    }
}
