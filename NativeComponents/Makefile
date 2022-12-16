CXXFLAGS := -std=c++11 -IImGui/ -fPIC
CXXLDFLAGS := -static-libgcc -static-libstdc++ -shared

-include common.mak

# (run_command, tag, path, preflags, source, postflags)
ifdef make_info
define run_command
	@$(make_info) $(1) $@ $(4) ';' $? ';'
	@$(2) $(3) $@ $(4) $(5)
endef
else
define run_command
	$(2) $(3) $@ $(4) $(5)
endef
endif

ifeq ($(OS),Windows_NT)
CXXLDFLAGS += -mwindows
.DEFAULT_GOAL: ImGuizmo-Bridge.dll
else
.DEFAULT_GOAL: libImGuizmo-Bridge.so
endif

.PHONY: clean

IMGUI_OBJS := $(addprefix ImGui/obj/, imgui.o imgui_tables.o imgui_widgets.o)
IMGUIZMO_OBJS := $(addprefix ImGuizmo/obj/, ImGuizmo.o GraphEditor.o ImCurveEdit.o ImGradient.o ImSequencer.o)
BRIDGE_OBJS := $(addprefix ImGuizmo.Bridge/obj/, )

ImGui/obj/%.o: ImGui/%.cpp ImGui/imgui.h ImGui/imgui_internal.h
	@mkdir -p $(@D)
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS))

ImGuizmo/obj/%.o: ImGuizmo/%.cpp ImGuizmo/%.h ImGui/imgui.h ImGui/imgui_internal.h
	@mkdir -p $(@D)
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS))

ImGuizmo/obj/%.o: ImGuizmo/%.cpp ImGui/imgui.h ImGui/imgui_internal.h
	@mkdir -p $(@D)
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS))

ImGuizmo.Bridge/obj/%.o: ImGuizmo.Bridge/src/%.cpp ImGuizmo.Bridge/include/%.h
	@mkdir -p $(@D)
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS) -IImGuizmo.Bridge/include)

ImGuizmo.Bridge/obj/%.o: ImGuizmo.Bridge/src/%.cpp
	@mkdir -p $(@D)
	$(call run_command, CXX, $(CXX), -c -o, $<, $(CXXFLAGS) -IImGuizmo.Bridge/include)


libImGuizmo-Bridge.so: $(IMGUI_OBJS) $(IMGUIZMO_OBJS) $(BRIDGE_OBJS)
	$(call run_command, CXXLD, $(CXX), -o, $^, $(CXXFLAGS) $(CXXLDFLAGS))

ImGuizmo-Bridge.dll: $(IMGUI_OBJS) $(IMGUIZMO_OBJS) $(BRIDGE_OBJS)
	$(call run_command, CXXLD, $(CXX), -o, $^, $(CXXFLAGS))

clean:
	$(RM) -rf ImGui/obj/
	$(RM) -rf ImGuizmo/obj/
	$(RM) -rf ImGuizmo.Bridge/obj/
	$(RM) libImGuizmo-Bridge.so
	$(RM) ImGuizmo-Bridge.dll
