#!/usr/bin/python3
# -*- encoding: utf-8 -*-
import csv, sys, numpy
from PresentInfo import PresentInfo

def read_csv_file(file_name):
    records = []
    with open(file_name) as csvfile:
        reader = csv.reader(csvfile, delimiter=',')
        for row in reader:
            try:
                records.append(PresentInfo(float(row[9]), float(row[10]), float(row[11]), float(row[12]), float(row[13])))
            except:
                print('Not valid, pass')

    return records


def calculate_average(list_present_info):
    fps = 0
    for item in list_present_info:
        fps = fps + float(item.frames_per_second())

    return fps / (len(list_present_info))


def calculate_min(list_present_info):
    minimum = 800
    for item in list_present_info:
        if minimum > item.frames_per_second() and item.frames_per_second() > 5:
            minimum = item.frames_per_second()

    return minimum


def calculate_max(list_present_info):
    maximum = 0
    for item in list_present_info:
        if maximum < item.frames_per_second() and item.frames_per_second() < 200:
            maximum = item.frames_per_second()

    return maximum


def standard_deviation(list_present_info):
    fps = []
    for item in list_present_info:
        if item.frames_per_second() < 200 and item.frames_per_second() > 5:
            fps.append(item.frames_per_second())

    return numpy.std(fps, axis = 0)


if __name__ == '__main__':
    if len(sys.argv) == 2:
        print(sys.argv[1])
        list_present_info = read_csv_file(sys.argv[1])
        avg = calculate_average(list_present_info)
        minimum = calculate_min(list_present_info)
        maximum = calculate_max(list_present_info)
        sd = standard_deviation(list_present_info)

        print('Average: ' + str(round(avg)))
        print('Minimum: ' + str(round(minimum)))
        print('Maximum: ' + str(round(maximum)))
        print('Standard deviation: ' + str(sd))
    else:
        'ERROR. Invalid number of arguments.'
