#include "bridge.h"

void Ktisis_ImGuizmo_SetImGuiContext(ImGuiContext* ctx) {
	ImGuizmo::SetImGuiContext(ctx);
}

void Ktisis_ImGuizmo_SetAllocatorFunctions(ImGuiMemAllocFunc alloc, ImGuiMemFreeFunc free, void* ud) {
	ImGui::SetAllocatorFunctions(alloc, free, ud);
}


void Ktisis_ImGuizmo_DecomposeMatrixToComponents(const float* matrix, float* translation, float* rotation, float* scale) {
	ImGuizmo::DecomposeMatrixToComponents(matrix, translation, rotation, scale);
}

void Ktisis_ImGuizmo_RecomposeMatrixFromComponents(const float* translation, const float* rotation, const float* scale, float* matrix) {
	ImGuizmo::RecomposeMatrixFromComponents(translation, rotation, scale, matrix);
}


ImGuizmo::Style* Ktisis_ImGuizmo_GetStyle() {
	/* ref-to-ptr conversion, to my knowledge this is safe and fine. */
	return &ImGuizmo::GetStyle();
}


void Ktisis_ImGuizmo_AllowAxisFlip(bool value) { ImGuizmo::AllowAxisFlip(value); }
void Ktisis_ImGuizmo_BeginFrame() { ImGuizmo::BeginFrame(); }
void Ktisis_ImGuizmo_SetDrawlist(ImDrawList* drawList) { ImGuizmo::SetDrawlist(drawList); }
void Ktisis_ImGuizmo_SetRect(float x, float y, float width, float height) { ImGuizmo::SetRect(x, y, width, height); }
void Ktisis_ImGuizmo_Enable(bool enabled) { ImGuizmo::Enable(enabled); }
bool Ktisis_ImGuizmo_Manipulate(
	const float* view,
	const float* projection,
	ImGuizmo::OPERATION operation,
	ImGuizmo::MODE mode,
	float* matrix,
	float* deltaMatrix,
	const float* snap,
	const float* localBounds,
	const float* boundsSnap
) {
	return ImGuizmo::Manipulate(view, projection, operation, mode, matrix, deltaMatrix, snap, localBounds, boundsSnap);
}

bool Ktisis_ImGuizmo_IsUsing() { return ImGuizmo::IsUsing(); }
bool Ktisis_ImGuizmo_IsOver0() { return ImGuizmo::IsOver(); }