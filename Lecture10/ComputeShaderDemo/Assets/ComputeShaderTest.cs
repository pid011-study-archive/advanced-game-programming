using UnityEngine;

public class ComputeShaderTest : MonoBehaviour
{
    public ComputeShader _computeShader;

    private int _kernelIndex_KernelFunction_A;
    private int _kernelIndex_KernelFunction_B;

    private ComputeBuffer _intComputeBuffer;

    private void Start()
    {
        _kernelIndex_KernelFunction_A = _computeShader.FindKernel("KernelFunction_A");
        _kernelIndex_KernelFunction_B = _computeShader.FindKernel("KernelFunction_B");

        _intComputeBuffer = new ComputeBuffer(4, sizeof(int));
        _computeShader.SetBuffer(_kernelIndex_KernelFunction_A, "intBuffer", _intComputeBuffer);

        _computeShader.SetInt("intValue", 1);

        _computeShader.Dispatch(_kernelIndex_KernelFunction_A, 1, 1, 1);
        int[] result = new int[4];
        _intComputeBuffer.GetData(result);

        for (int i = 0; i < 4; i++) Debug.Log(result[i]);

        _computeShader.SetBuffer(_kernelIndex_KernelFunction_B, "intBuffer", _intComputeBuffer);
        _computeShader.Dispatch(_kernelIndex_KernelFunction_B, 1, 1, 1);
        _intComputeBuffer.GetData(result);

        for (int i = 0; i < 4; i++) Debug.Log(result[i]);

        _intComputeBuffer.Release();
    }
}
