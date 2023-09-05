using System;
using System.Runtime.InteropServices;

namespace Ktisis.ImGuizmo;

internal static class NativeInterface {
	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_SetImGuiContext(IntPtr ctx);
	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_SetAllocatorFunctions(IntPtr alloc, IntPtr free, IntPtr ud);

	[DllImport("ImGuizmo-Bridge")]
	extern internal static unsafe void Ktisis_ImGuizmo_DecomposeMatrixToComponents(float* matrix, float* translation, float* rotation, float* scale);
	[DllImport("ImGuizmo-Bridge")]
	extern internal static unsafe void Ktisis_ImGuizmo_RecomposeMatrixFromComponents(float* translation, float* rotation, float* scale, float* matrix);

	[DllImport("ImGuizmo-Bridge")]
	extern internal static unsafe Style* Ktisis_ImGuizmo_GetStyle();

	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_AllowAxisFlip(bool value);

	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_BeginFrame();
	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_SetDrawlist(IntPtr drawList);
	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_SetRect(float x, float y, float width, float height);
	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_SetID(int id);
	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_SetGizmoSizeClipSpace(float value);
	[DllImport("ImGuizmo-Bridge")]
	extern internal static void Ktisis_ImGuizmo_Enable(bool enabled);

	[DllImport("ImGuizmo-Bridge")]
	extern internal static unsafe bool Ktisis_ImGuizmo_Manipulate(
		float* view,
		float* projection,
		Operation operation,
		Mode mode,
		float* matrix,
		float* deltaMatrix,
		float* snap,
		float* localBounds,
		float* boundsSnap
	);

	[DllImport("ImGuizmo-Bridge")]
	extern internal static bool Ktisis_ImGuizmo_IsUsing();
	[DllImport("ImGuizmo-Bridge")]
	extern internal static bool Ktisis_ImGuizmo_IsOver0();

}
