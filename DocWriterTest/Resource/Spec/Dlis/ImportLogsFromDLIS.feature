Feature: Import Logs From DLIS File
	In order to use log channels from DLIS file for log squaring
	As a WP engineer
	I want to import log channels to offset well from a DLIS file


Scenario: 1. Import a DLIS file and preview basic information and the all channels
	
	Given I have a DLIS file "DlisWithLogAndBHImage.Dlis"  
	When  I import file
	Then  I will get basic information
			| Logic Files | Frames | Channels |
			| 1           | 1      | 7        |
	And   I will get channel list
			| Name		| Unit   | Spacing | Measurement | Description                                                                                |
			| GR_IMAGE	| gAPI	 | 6in     | APIGammaRay | Gamma Ray Image																			  |
			| A16H_RT	| ohm.m  | 6in     | Resistivity | ARC Attenuation Resistivity 16 inch Spacing at 2 MHz, Environmentally Corrected, Real-Time |
			| DEVI		| deg	 | 6in     | PhaseShift  | Hole Deviation                                                                             |
			| MD		| 0.1 in | 6in     |             | Measured Depth                                                                             |
			| TDEP      | 0.1 in | 6in     |             | Tool Depth	                                                                              |
			| AREA      | in2    | 6in     |             | Area of Borehole                                                                           |
			| TEMP      | degF   | 6in     |             | Computed Borehole Temperature                                                              |
