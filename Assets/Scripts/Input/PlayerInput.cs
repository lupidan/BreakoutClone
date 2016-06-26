
public interface PlayerInput {

    float UpdateHorizontalPosition(float currentHorizontalPosition);
	bool ActionButtonPressed { get; }
    bool PauseButtonPressed { get; }

}
