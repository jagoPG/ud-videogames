#!/usr/bin/python3
# -*- encoding: utf-8 -*-
class PresentInfo:
    def __init__(self, time_in_seconds, ms_between_presents, ms_between_display_change, ms_until_render_complete, \
        ms_until_displayed):
        self.time_in_seconds = time_in_seconds
        self.ms_between_presents = ms_between_presents
        self.ms_between_display_change = ms_between_display_change
        self.ms_until_render_complete = ms_until_render_complete
        self.ms_until_displayed = ms_until_displayed

    def time_in_seconds(self):
        return self.time_in_seconds

    def ms_between_presents(self):
        return self.ms_between_presents

    def ms_between_display_change(self):
        return self.ms_between_display_change

    def ms_until_render_complete(self):
        return self.ms_until_render_complete

    def ms_until_displayed(self):
        return self.ms_until_displayed

    def frames_per_second(self):
        return 1000 / self.ms_between_presents
