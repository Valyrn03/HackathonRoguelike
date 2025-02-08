extends Button 

@export var boat: Boat
@export var player: Player


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	self.pressed.connect(_on_button_pressed)


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	pass

func _on_button_pressed():
	print("Click!")
	if boat and player:
		boat.upgrade(player)  # Pass the player object to check for tools
